using Grpc.Core;
using Tgs.GameInterface.AwcService.Core;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Protos;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.GrpcServices;

public class GameInterfaceAwcRecordGrpcService : GameInterfaceAwcRecordService.GameInterfaceAwcRecordServiceBase
{
    private readonly IQueryService<OutstandingByBetTimeQuery, OutstandingByBetTimeResult> _outstandingByBetTimeService;
    private readonly IQueryService<TransactionByTxTimeQuery, TransactionByTxTimeResult> _transactionByTxTimeQuery;
    private readonly IQueryService<TransactionByUpdateDateByStatusQuery, TransactionByUpdateDateResult> _transactionByUpdateDateByStatusService;
    private readonly IQueryService<TransactionByUpdateDateQuery, TransactionByUpdateDateResult> _transactionByUpdateDateService;

    public GameInterfaceAwcRecordGrpcService(
        IQueryService<TransactionByTxTimeQuery, TransactionByTxTimeResult> transactionByTxTimeQuery,
        IQueryService<OutstandingByBetTimeQuery, OutstandingByBetTimeResult> outstandingByBetTimeService,
        IQueryService<TransactionByUpdateDateQuery, TransactionByUpdateDateResult> transactionByUpdateDateService,
        IQueryService<TransactionByUpdateDateByStatusQuery, TransactionByUpdateDateResult> transactionByUpdateDateByStatusService)
    {
        _transactionByTxTimeQuery = transactionByTxTimeQuery ?? throw new ArgumentNullException(nameof(transactionByTxTimeQuery));
        _outstandingByBetTimeService = outstandingByBetTimeService ?? throw new ArgumentNullException(nameof(outstandingByBetTimeService));
        _transactionByUpdateDateService = transactionByUpdateDateService ?? throw new ArgumentNullException(nameof(transactionByUpdateDateService));
        _transactionByUpdateDateByStatusService = transactionByUpdateDateByStatusService ?? throw new ArgumentNullException(nameof(transactionByUpdateDateByStatusService));
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcAeLotto(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_AELOTTO,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcAws(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_AWS,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcCockfight(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_COCKFIGHT,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcFacai(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_FACAI,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcFs(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_FS,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcKm(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_KM,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcLudo(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_LUDO,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcPgs(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_PGS,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcRcb(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_RCB,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcSg(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_SG,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcSpade(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_SPADE,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcVenus(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_VENUS,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcYl(GameInterfaceAwcServiceGamePullRecordeRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateService.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_YL,
            TimeFrom: request.TimeFrom.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGamePullRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGamePullRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcAeLotto(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_AELOTTO,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcAws(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_AWS,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcCockfight(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_COCKFIGHT,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcFacai(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_FACAI,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcFs(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_FS,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcKm(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_KM,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcLudo(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_LUDO,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcPgs(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_PGS,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcRcb(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_RCB,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcSg(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_SG,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcSpade(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_SPADE,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcVenus(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_VENUS,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcYl(GameInterfaceAwcServiceGameSettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByTxTimeQuery.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_YL,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameSettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameSettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                TxStatus = transaction.TxStatus,
                SettleStatus = transaction.SettleStatus,
                BetTime = transaction.BetTime,
                TxTime = transaction.TxTime,
                UpdateTime = transaction.UpdateTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                Turnover = transaction.Turnover,
                WinAmount = transaction.WinAmount,
                RealWinAmount = transaction.RealWinAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                JackpotWinAmount = transaction.JackpotWinAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameUnsettleRecordReply> GameUnsettleByAwcAeLotto(GameInterfaceAwcServiceGameUnsettleRequest request, ServerCallContext context)
    {
        var result = await _outstandingByBetTimeService.QueryAsync(new OutstandingByBetTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_AELOTTO,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameUnsettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameUnsettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                BetTime = transaction.BetTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameUnsettleRecordReply> GameUnsettleByAwcCockfight(GameInterfaceAwcServiceCockFightGameUnsettleRequest request, ServerCallContext context)
    {
        var result = await _transactionByUpdateDateByStatusService.QueryAsync(new TransactionByUpdateDateByStatusQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_COCKFIGHT,
            TimeFrom: request.TimeFrom.ToDateTimeOffset(),
            TransactionStatus: TransactionStatus.Bet)).ToArrayAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameUnsettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameUnsettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                BetTime = transaction.BetTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }

    public override async Task<GameInterfaceAwcServiceGameUnsettleRecordReply> GameUnsettleByAwcRcb(GameInterfaceAwcServiceGameUnsettleRequest request, ServerCallContext context)
    {
        var result = await _outstandingByBetTimeService.QueryAsync(new OutstandingByBetTimeQuery(
            ApiUrl: new(request.ApiUrl),
            AgentId: request.AgentId,
            Cert: request.Cert,
            Platform: AwcPlatforms.AWC_RCB,
            StartTime: request.StartTime.ToDateTimeOffset(),
            EndTime: request.EndTime.ToDateTimeOffset())).ToListAsync().ConfigureAwait(false);

        var reply = new GameInterfaceAwcServiceGameUnsettleRecordReply();

        if (result is null)
        {
            return reply;
        }

        foreach (var transaction in result)
        {
            reply.Items.Add(new GameInterfaceAwcServiceGameUnsettleRecord()
            {
                ExternalRoundId = transaction.ExternalRoundId,
                Platform = transaction.Platform,
                PlatformTxId = transaction.PlatformTxId,
                GameType = transaction.GameType,
                GameCode = transaction.GameCode,
                GameName = transaction.GameName,
                RoundId = transaction.RoundId,
                UserId = transaction.UserId,
                Currency = transaction.Currency,
                BetTime = transaction.BetTime,
                BetType = transaction.BetType,
                BetAmount = transaction.BetAmount,
                RealBetAmount = transaction.RealBetAmount,
                JackpotBetAmount = transaction.JackpotBetAmount,
                GameInfo = transaction.GameInfo
            });
        };

        return reply;
    }
}
