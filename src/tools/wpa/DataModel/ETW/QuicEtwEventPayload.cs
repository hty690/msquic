﻿//
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
//

using System;

namespace MsQuicTracing.DataModel.ETW
{
    internal class QuicWorkerCreatedEtwPayload : QuicWorkerCreatedPayload
    {
        internal QuicWorkerCreatedEtwPayload(ReadOnlySpan<byte> data, int pointerSize)
        {
            IdealProcessor = data.ReadValue<ushort>();
            OwnerPointer = data.ReadPointer(pointerSize);
        }
    }

    internal class QuicWorkerActivityStateUpdatedEtwPayload : QuicWorkerActivityStateUpdatedPayload
    {
        internal QuicWorkerActivityStateUpdatedEtwPayload(ReadOnlySpan<byte> data)
        {
            IsActive = data.ReadValue<byte>();
            Arg = data.ReadValue<uint>();
        }
    }

    internal class QuicWorkerQueueDelayUpdatedEtwPayload : QuicWorkerQueueDelayUpdatedPayload
    {
        internal QuicWorkerQueueDelayUpdatedEtwPayload(ReadOnlySpan<byte> data)
        {
            QueueDelay = data.ReadValue<uint>();
        }
    }

    internal class QuicConnectionCreatedEtwPayload : QuicConnectionCreatedPayload
    {
        internal QuicConnectionCreatedEtwPayload(ReadOnlySpan<byte> data)
        {
            IsServer = data.ReadValue<uint>();
            CorrelationId = data.ReadValue<ulong>();
        }
    }

    internal class QuicConnectionScheduleStateEtwPayload : QuicConnectionScheduleStatePayload
    {
        internal QuicConnectionScheduleStateEtwPayload(ReadOnlySpan<byte> data)
        {
            State = data.ReadValue<uint>();
        }
    }

    internal class QuicConnectionAssignWorkerEtwPayload : QuicConnectionAssignWorkerPayload
    {
        internal QuicConnectionAssignWorkerEtwPayload(ReadOnlySpan<byte> data, int pointerSize)
        {
            WorkerPointer = data.ReadPointer(pointerSize);
        }
    }

    internal class QuicConnectionTransportShutdownEtwPayload : QuicConnectionTransportShutdownPayload
    {
        internal QuicConnectionTransportShutdownEtwPayload(ReadOnlySpan<byte> data)
        {
            ErrorCode = data.ReadValue<ulong>();
            IsRemoteShutdown = data.ReadValue<byte>();
            IsQuicStatus = data.ReadValue<byte>();
        }
    }

    internal class QuicConnectionAppShutdownEtwPayload : QuicConnectionAppShutdownPayload
    {
        internal QuicConnectionAppShutdownEtwPayload(ReadOnlySpan<byte> data)
        {
            ErrorCode = data.ReadValue<ulong>();
            IsRemoteShutdown = data.ReadValue<byte>();
        }
    }

    internal class QuicConnectionOutFlowStatsEtwPayload : QuicConnectionOutFlowStatsPayload
    {
        internal QuicConnectionOutFlowStatsEtwPayload(ReadOnlySpan<byte> data)
        {
            BytesSent = data.ReadValue<ulong>();
            BytesInFlight = data.ReadValue<uint>();
            BytesInFlightMax = data.ReadValue<uint>();
            CongestionWindow = data.ReadValue<uint>();
            SlowStartThreshold = data.ReadValue<uint>();
            ConnectionFlowControl = data.ReadValue<ulong>();
            IdealBytes = data.ReadValue<ulong>();
            PostedBytes = data.ReadValue<ulong>();
            SmoothedRtt = data.ReadValue<uint>();
        }
    }

    internal class QuicConnectionOutFlowBlockedEtwPayload : QuicConnectionOutFlowBlockedPayload
    {
        internal QuicConnectionOutFlowBlockedEtwPayload(ReadOnlySpan<byte> data)
        {
            ReasonFlags = data.ReadValue<byte>();
        }
    }

    internal class QuicConnectionInFlowStatsEtwPayload : QuicConnectionInFlowStatsPayload
    {
        internal QuicConnectionInFlowStatsEtwPayload(ReadOnlySpan<byte> data)
        {
            BytesRecv = data.ReadValue<ulong>();
        }
    }

    internal class QuicConnectionStatsEtwPayload : QuicConnectionStatsPayload
    {
        internal QuicConnectionStatsEtwPayload(ReadOnlySpan<byte> data)
        {
            SmoothedRtt = data.ReadValue<uint>();
            CongestionCount = data.ReadValue<uint>();
            PersistentCongestionCount = data.ReadValue<uint>();
            SendTotalBytes = data.ReadValue<ulong>();
            RecvTotalBytes = data.ReadValue<ulong>();
        }
    }
}
