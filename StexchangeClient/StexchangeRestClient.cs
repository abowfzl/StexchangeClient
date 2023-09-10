using AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using StexchangeClient.Contracts;
using StexchangeClient.Enums;
using StexchangeClient.Exceptions;
using StexchangeClient.Models;
using StexchangeClient.Models.Response.Assets;
using StexchangeClient.Models.Response.Markets;
using StexchangeClient.Models.Response.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StexchangeClient
{
    public class StexchangeRestClient : IStexchangeRestClient, IDisposable
    {
        private bool _disposing;

        private readonly HttpClient _httpClient;

        public StexchangeRestClient(HttpClient httpClient)
        {
            if (httpClient.BaseAddress is null)
                throw new StexchangeException($"httpClient {nameof(httpClient.BaseAddress)} isn't configure");

            _httpClient = httpClient;
        }

        #region Assets

        public async Task<UpdateBalanceResponse> UpdateBalance<T>(int requestId, int userId, string assetName, string businessType, int businessId, decimal normalizeBalanceChange, T details, CancellationToken cancellationToken)
        {
            var jsonFormattedDetails = JsonConvert.SerializeObject(details);

            var DictionaryFormattedDetails = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonFormattedDetails);

            var requestParams = new List<object>()
            {
                userId,
                assetName.ToUpper(),
                businessType.ToLower(),
                businessId,
                normalizeBalanceChange.ToString(),
                DictionaryFormattedDetails!
            };

            var requestContent = CreateJsonRequestContent(requestId, "balance.update", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var customExceptions = new Dictionary<int, StexchangeException>()
            {
                { 10, new BalanceNotEnoughException(requestId)},
                { 11, new RepeatUpdateException(requestId)}
            };

            var response = await GetResponse<UpdateBalanceResponse>(httpResponse, customExceptions);

            return response.Result;
        }

        public async Task<PagedStexchangeResponse<BalanceHistoryDetail>> GetBalanceHistory(int requestId, int userId, CancellationToken cancellationToken, string assetName = null, string businessType = null, double startTime = 0, double endTime = 0, int offset = 0, int limit = 0, int beforeId = 0, int afterId = 0)
        {
            var requestParams = new List<object>()
            {
                userId,
                assetName.ToUpper(),
                businessType.ToLower(),
                startTime,
                endTime,
                offset,
                limit,
                afterId,
                beforeId
            };

            var requestContent = CreateJsonRequestContent(requestId, "balance.history", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<PagedStexchangeResponse<BalanceHistoryDetail>>(httpResponse);

            return response.Result;
        }

        public async Task<Dictionary<string, BalanceQueryResponse>> GetBalanceQueries(int requestId, int userId, CancellationToken cancellationToken, params string[] assetNames)
        {
            var requestParams = new List<object>()
            {
                userId
            };

            var requestContent = CreateJsonRequestContent(requestId, "balance.query", requestParams.Concat(assetNames.Select(an => an.ToUpper()).ToArray()));

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<Dictionary<string, BalanceQueryResponse>>(httpResponse);

            return response.Result;
        }

        public async Task<IList<AssetListResponse>> GetAssetList(int requestId, CancellationToken cancellationToken)
        {
            var requestContent = CreateJsonRequestContent(requestId, "asset.list", Array.Empty<string>());

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<IList<AssetListResponse>>(httpResponse);

            return response.Result;
        }

        public async Task<IList<AssetSummaryResponse>> GetAssetSummary(int requestId, CancellationToken cancellationToken)
        {
            var requestContent = CreateJsonRequestContent(requestId, "asset.summary", Array.Empty<string>());

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<IList<AssetSummaryResponse>>(httpResponse);

            return response.Result;
        }

        #endregion

        #region Trades

        public async Task<OrderDetailResponse> PutLimitOrder(int requestId, int userId, string marketName, OrderSide orderSide, decimal amount, decimal price, decimal takerFeeRate, decimal makerFeeRate, string source, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                userId,
                marketName,
                (int)orderSide,
                amount.ToString(),
                price.ToString(),
                takerFeeRate.ToString(),
                makerFeeRate.ToString(),
                source
            };

            var requestContent = CreateJsonRequestContent(requestId, "order.put_limit", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var customExceptions = new Dictionary<int, StexchangeException>()
            {
                { 10, new BalanceNotEnoughException(requestId)}
            };

            var response = await GetResponse<OrderDetailResponse>(httpResponse, customExceptions);

            return response.Result;
        }

        public async Task<OrderDetailResponse> PutMarketOrder(int requestId, int userId, string marketName, OrderSide orderSide, decimal amount, decimal takerFeeRate, string source, CancellationToken cancellationToken, bool bidAmountMoney = false)
        {
            var requestParams = new List<object>
            {
                userId,
                marketName,
                (int)orderSide,
                amount.ToString(),
                takerFeeRate.ToString(),
                source,
                bidAmountMoney.ToString()
            };

            var requestContent = CreateJsonRequestContent(requestId, "order.put_market", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var customExceptions = new Dictionary<int, StexchangeException>()
            {
                { 10, new BalanceNotEnoughException(requestId)},
                { 11, new TooSmallAmountException(requestId)}
            };

            var response = await GetResponse<OrderDetailResponse>(httpResponse, customExceptions);


            return response.Result;
        }

        public async Task<OrderDetailResponse> CancelOrder(int requestId, int userId, string marketName, int orderId, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                 userId,
                 marketName,
                 orderId
            };

            var requestContent = CreateJsonRequestContent(requestId, "order.cancel", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var customExceptions = new Dictionary<int, StexchangeException>()
            {
                { 10, new OrderNotFoundException(requestId)},
                { 11, new UserNotMatchException(requestId)}
            };

            var response = await GetResponse<OrderDetailResponse>(httpResponse, customExceptions);

            return response.Result;
        }

        public async Task<PagedStexchangeResponse<OrderDealDetailResponse>> GetOrderDeals(int requestId, int orderId, int offset, int limit, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                orderId,
                offset,
                limit
            };

            var requestContent = CreateJsonRequestContent(requestId, "order.deals", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<PagedStexchangeResponse<OrderDealDetailResponse>>(httpResponse);

            return response.Result;
        }

        public async Task<OrderBookResponse> GetOrderBooks(int requestId, string marketName, OrderSide orderSide, int offset, int limit, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                marketName,
                orderSide,
                offset,
                limit
            };

            var requestContent = CreateJsonRequestContent(requestId, "order.book", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<OrderBookResponse>(httpResponse);

            return response.Result;
        }

        public async Task<OrderDepthResponse> GetOrderDepth(int requestId, string marketName, int limit, string interval, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                marketName,
                limit,
                interval
            };

            var requestContent = CreateJsonRequestContent(requestId, "order.depth", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<OrderDepthResponse>(httpResponse);

            return response.Result;
        }

        public async Task<PagedStexchangeResponse<OrderDetailResponse>> GetPendingOrders(int requestId, int userId, string marketName, int offset, int limit, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                userId,
                marketName,
                offset,
                limit
            };

            var requestContent = CreateJsonRequestContent(requestId, "order.pending", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<PagedStexchangeResponse<OrderDetailResponse>>(httpResponse);

            return response.Result;
        }

        public async Task<OrderDetailResponse> GetPendingOrderDetail(int requestId, string marketName, int orderId, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                marketName,
                orderId
            };

            var requestContent = CreateJsonRequestContent(requestId, "order.pending_detail", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<OrderDetailResponse>(httpResponse);

            return response.Result;
        }

        public async Task<PagedStexchangeResponse<OrderDetailResponse>> GetFinishedOrders(int requestId, int userId, string marketName, double startTime, double endTime, int offset, int limit, OrderSide orderSide, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                userId,
                marketName,
                startTime,
                endTime,
                offset,
                limit,
                orderSide
            };

            var requestContent = CreateJsonRequestContent(requestId, "order.finished", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<PagedStexchangeResponse<OrderDetailResponse>>(httpResponse);

            return response.Result;
        }

        public async Task<OrderDetailResponse> GetFinishedOrderDetail(int requestId, int orderId, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                orderId
            };

            var requestContent = CreateJsonRequestContent(requestId, "order.finished_detail", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<OrderDetailResponse>(httpResponse);

            return response.Result;
        }

        #endregion

        #region Markets

        public async Task<string> GetMarketLast(int requestId, string marketName, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                marketName
            };

            var requestContent = CreateJsonRequestContent(requestId, "market.last", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<string>(httpResponse);

            return response.Result;
        }

        public async Task<Dictionary<string, string>> GetAllMarketLast(int requestId, CancellationToken cancellationToken)
        {
            var allMarkets = await GetAllMarkets(requestId, cancellationToken);

            var marketsName = allMarkets.Select(x => x.Name).ToList();

            var result = new Dictionary<string, string>();

            foreach (var marketName in marketsName)
            {
                var marketStatus = await GetMarketLast(requestId, marketName, cancellationToken);
                result.Add(marketName, marketStatus);
            }

            return result;
        }

        public async Task<IList<MarketDealDetailResponse>> GetMarketDeals(int requestId, string marketName, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                marketName
            };

            var requestContent = CreateJsonRequestContent(requestId, "market.deals", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<IList<MarketDealDetailResponse>>(httpResponse);

            return response.Result;
        }

        public async Task<PagedStexchangeResponse<OrderDealDetailResponse>> GetMarketUserDeals(int requestId, int userId, string marketName, int offset, int limit, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                userId,
                marketName,
                offset,
                limit
            };

            var requestContent = CreateJsonRequestContent(requestId, "market.user_deals", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<PagedStexchangeResponse<OrderDealDetailResponse>>(httpResponse);

            return response.Result;
        }

        public async Task<MarkerStatusResponse> GetMarketStatus(int requestId, string marketName, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                marketName
            };

            var requestContent = CreateJsonRequestContent(requestId, "market.status", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<MarkerStatusResponse>(httpResponse);

            return response.Result;
        }

        public async Task<Dictionary<string, MarkerStatusResponse>> GetAllMarketStatus(int requestId, int periodCycle, CancellationToken cancellationToken)
        {
            var allMarkets = await GetAllMarkets(requestId, cancellationToken);

            var marketsName = allMarkets.Select(x => x.Name).ToList();

            var result = new Dictionary<string, MarkerStatusResponse>();

            foreach (var marketName in marketsName)
            {
                var marketStatus = await GetMarketStatus(requestId, marketName, cancellationToken);
                result.Add(marketName, marketStatus);
            }

            return result;
        }

        public async Task<MarketTodayStatusResponse> GetMarketTodayStatus(int requestId, string marketName, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                marketName
            };

            var requestContent = CreateJsonRequestContent(requestId, "market.status_today", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<MarketTodayStatusResponse>(httpResponse);

            return response.Result;
        }

        public async Task<IList<MarketResponse>> GetAllMarkets(int requestId, CancellationToken cancellationToken)
        {
            var requestContent = CreateJsonRequestContent(requestId, "market.list", Array.Empty<string>());

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<IList<MarketResponse>>(httpResponse);

            return response.Result;
        }

        public async Task<MarketSummaryResponse> GetMarketSummary(int requestId, string marketName, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                marketName
            };

            var requestContent = CreateJsonRequestContent(requestId, "market.summary", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<MarketSummaryResponse>(httpResponse);

            return response.Result;
        }

        public async Task<IList<List<object>>> GetMarketKline(int requestId, string marketName, int start, int end, int interval, CancellationToken cancellationToken)
        {
            var requestParams = new List<object>()
            {
                  marketName,
                  start.ToString(),
                  end.ToString(),
                  interval.ToString()
            };

            var requestContent = CreateJsonRequestContent(requestId, "market.kline", requestParams);

            var httpResponse = await _httpClient.PostAsync("/", requestContent, cancellationToken);

            var response = await GetResponse<IList<List<object>>>(httpResponse);

            return response.Result;
        }

        #endregion

        #region Private members

        private StringContent CreateJsonRequestContent(int requestId, string methodPayload, IEnumerable<object> parameters)
        {
            var content = JsonConvert.SerializeObject(new StexchangeRequest()
            {
                Id = requestId,
                Params = parameters,
                Method = methodPayload,
            });
            var jsonContent = new StringContent(content, Encoding.UTF8, "application/json");

            return jsonContent;
        }

        private async Task<BaseStexchangeResponse<T>> GetResponse<T>(HttpResponseMessage httpResponseMessage, Dictionary<int, StexchangeException> customExceptionMapper = null) where T : class
        {
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await httpResponseMessage.Content.ReadAsJsonAsync<BaseStexchangeResponse<T>>();

                CheckResponseErrors(response, customExceptionMapper);

                return response;
            }
            else
                throw new StexchangeUnknownException($"an error during call {nameof(StexchangeRestClient)}. status code: {httpResponseMessage.StatusCode}");

        }

        private void CheckResponseErrors<T>(BaseStexchangeResponse<T> stexchangeResponse, Dictionary<int, StexchangeException> customExceptionMapper = null) where T : class
        {
            if (stexchangeResponse.Error == null)
            {
                if (stexchangeResponse.Result == null)
                    throw new EmptyResponseException(stexchangeResponse.Id);

                return;
            }

            if (customExceptionMapper != null && customExceptionMapper.TryGetValue(stexchangeResponse.Error.Code, out var customException))
            {
                throw customException;
            }


            switch (stexchangeResponse.Error.Code)
            {
                case 1: throw new InvalidArgumentException(stexchangeResponse.Id);
                case 2: throw new InternalErrorException(stexchangeResponse.Id);
                case 3: throw new ServiceUnavailableException(stexchangeResponse.Id);
                case 4: throw new MethodNotFoundException(stexchangeResponse.Id);
                case 5: throw new ServiceTimoutException(stexchangeResponse.Id);
            }
        }

        #endregion

        #region Dispose

        public virtual void Dispose()
        {
            _disposing = true;
        }

        #endregion
    }
}