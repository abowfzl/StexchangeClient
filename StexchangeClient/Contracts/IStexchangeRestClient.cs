using StexchangeClient.Enums;
using StexchangeClient.Models;
using StexchangeClient.Models.Response.Assets;
using StexchangeClient.Models.Response.Markets;
using StexchangeClient.Models.Response.Orders;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StexchangeClient.Contracts
{
    public interface IStexchangeRestClient
    {
        #region Assert

        Task<UpdateBalanceResponse> UpdateBalance<T>(int requestId, int userId, string assetName, string businessType, int businessId, decimal balanceChange, T details, CancellationToken cancellationToken);

        Task<PagedStexchangeResponse<BalanceHistoryDetail>> GetBalanceHistory(int requestId, int userId, CancellationToken cancellationToken, string assetName = null, string businessType = null, double startTime = 0, double endTime = 0, int offset = 0, int limit = 0, int beforeId = 0, int afterId = 0);

        Task<Dictionary<string, BalanceQueryResponse>> GetBalanceQueries(int requestId, int userId, CancellationToken cancellationToken, params string[] assetNames);

        Task<IList<AssetListResponse>> GetAssetList(int requestId, CancellationToken cancellationToken);

        Task<IList<AssetSummaryResponse>> GetAssetSummary(int requestId, CancellationToken cancellationToken);

        #endregion

        #region Trades

        Task<OrderDetailResponse> PutLimitOrder(int requestId, int userId, string marketName, OrderSide orderSide, decimal amount, decimal price, decimal takerFeeRate, decimal makerFeeRate, string source, CancellationToken cancellationToken);

        Task<OrderDetailResponse> PutMarketOrder(int requestId, int userId, string marketName, OrderSide orderSide, decimal amount, decimal takerFeeRate, string source, CancellationToken cancellationToken, bool bidAmountMoney = false);

        Task<OrderDetailResponse> CancelOrder(int requestId, int userId, string marketName, int orderId, CancellationToken cancellationToken);

        Task<PagedStexchangeResponse<OrderDealDetailResponse>> GetOrderDeals(int requestId, int orderId, int offset, int limit, CancellationToken cancellationToken);

        Task<OrderBookResponse> GetOrderBooks(int requestId, string marketName, OrderSide orderSide, int offset, int limit, CancellationToken cancellationToken);

        Task<OrderDepthResponse> GetOrderDepth(int requestId, string marketName, int limit, string interval, CancellationToken cancellationToken);

        Task<PagedStexchangeResponse<OrderDetailResponse>> GetPendingOrders(int requestId, int userId, string marketName, int offset, int limit, CancellationToken cancellationToken);

        Task<OrderDetailResponse> GetPendingOrderDetail(int requestId, string marketName, int orderId, CancellationToken cancellationToken);

        Task<PagedStexchangeResponse<OrderDetailResponse>> GetFinishedOrders(int requestId, int userId, string marketName, double startTime, double endTime, int offset, int limit, OrderSide orderSide, CancellationToken cancellationToken);

        Task<OrderDetailResponse> GetFinishedOrderDetail(int requestId, int orderId, CancellationToken cancellationToken);

        #endregion

        #region Markets

        Task<string> GetMarketLast(int requestId, string marketName, CancellationToken cancellationToken);

        Task<Dictionary<string, string>> GetAllMarketLast(int requestId, CancellationToken cancellationToken);

        Task<IList<MarketDealDetailResponse>> GetMarketDeals(int requestId, string marketName, CancellationToken cancellationToken);

        Task<PagedStexchangeResponse<OrderDealDetailResponse>> GetMarketUserDeals(int requestId, int userId, string marketName, int offset, int limit, CancellationToken cancellationToken);

        Task<MarkerStatusResponse> GetMarketStatus(int requestId, string marketName, CancellationToken cancellationToken);

        Task<Dictionary<string, MarkerStatusResponse>> GetAllMarketStatus(int requestId, int periodCycle, CancellationToken cancellationToken);

        Task<MarketTodayStatusResponse> GetMarketTodayStatus(int requestId, string marketName, CancellationToken cancellationToken);

        Task<IList<MarketResponse>> GetAllMarkets(int requestId, CancellationToken cancellationToken);

        Task<MarketSummaryResponse> GetMarketSummary(int requestId, string marketName, CancellationToken cancellationToken);

        Task<IList<List<object>>> GetMarketKline(int requestId, string marketName, int start, int end, int interval, CancellationToken cancellationToken);

        #endregion
    }
}