using Google.Protobuf.WellKnownTypes;

using Grpc.Core;
using Tgs.GameInterface.Awc.Core;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.Protos;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.GrpcServices;

public class GameInterfaceAwcRecordGrpcService(
    IQueryService<GameWagerSettledQuery, GameWagerResult> gameRecordByUpdateSerivce,
    IQueryService<GameWagerQuery, GameWagerResult> gameRecordService,
    IQueryService<GameWagerUnsettledQuery, GameWagerResult> gameRecordUnsettledService) : GameInterfaceAwcRecord.GameInterfaceAwcRecordBase
{
    public override async Task<GameWagerReply> GamePullRecordByAwcAeLotto(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_AELOTTO,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcAws(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_AWS,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcBg(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_BG,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcCockfight(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_COCKFIGHT,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcFacai(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_FACAI,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcFs(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_FS,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcKm(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_KM,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcLudo(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_LUDO,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcPgs(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_PGS,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcRcb(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_RCB,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcSg(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_SG,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcSpade(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_SPADE,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcVenus(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_VENUS,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcYesbingo(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_YESBINGO,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GamePullRecordByAwcYl(GamePullRecordeRequest request, ServerCallContext context)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_YL,
            TimeFrom: request.TimeFrom.ToDateTimeOffset());

        var results = await gameRecordByUpdateSerivce.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcAeLotto(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_AELOTTO,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcAws(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_AWS,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcBg(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_BG,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcCockfight(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_COCKFIGHT,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcFacai(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_FACAI,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcFs(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_FS,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcKm(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_KM,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcLudo(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_LUDO,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcPgs(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_PGS,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            cancellationToken: context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcRcb(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_RCB,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            cancellationToken: context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcSg(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_SG,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            cancellationToken: context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcSpade(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_SPADE,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            cancellationToken: context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcVenus(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_VENUS,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            cancellationToken: context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcYesbingo(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_YESBINGO,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            cancellationToken: context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameSettleByAwcYl(GameSettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_YL,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            cancellationToken: context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameUnsettleByAwcAeLotto(GameUnsettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerUnsettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_AELOTTO,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordUnsettledService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            cancellationToken: context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameUnsettleByAwcCockfight(GameUnsettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerUnsettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_COCKFIGHT,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordUnsettledService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            cancellationToken: context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }

    public override async Task<GameWagerReply> GameUnsettleByAwcRcb(GameUnsettleRequest request, ServerCallContext context)
    {
        var query = new GameWagerUnsettledQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_RCB,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset());

        var results = await gameRecordUnsettledService.QueryAsync(
            query: query,
            cancellationToken: context.CancellationToken)
            .ToArrayAsync(
            cancellationToken: context.CancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        var reply = new GameWagerReply();

        if (results.Any())
        {
            reply.Items.AddRange(results.Select(selector: result => new GameWagerInfo
            {
                ExternalRoundId = result.ExternalRoundId,
                ExternalWagerId = result.ExternalWagerId,
                ExternalGameId = result.ExternalGameId,
                PlayerCode = result.PlayerCode,
                IsClosed = result.IsClosed,
                IsCanceled = result.IsCanceled,
                IsVoid = result.IsVoid,
                IsCashout = result.IsCashout,
                ExternalCreatedOn = result.ExternalCreatedOn.ToTimestamp(),
                ExternalClosedOn = result.ExternalClosedOn.ToTimestamp(),
                Bet = result.Bet,
                ValidBet = result.ValidBet,
                Settle = result.Settle,
                Turnover = result.Turnover,
                WinLoss = result.WinLoss,
                AdditionalData = result.AdditionalData
            }));
        };
        return reply;
    }
}
