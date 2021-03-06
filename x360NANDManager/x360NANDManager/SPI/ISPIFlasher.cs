﻿namespace x360NANDManager.SPI {
    using System;
    using System.Collections.Generic;

    public interface ISPIFlasher : IFlasherOutput {
        void Init(out XConfig config);

        void DeInit();

        void Release();

        void Reset();

        void Abort();

        #region Erase

        void EraseBlock(uint blockID, int verboseLevel = 0);

        void Erase(uint startBlock, uint blockCount, int verboseLevel = 0);

        #endregion Erase

        #region Write

        void WriteBlock(uint blockID, byte[] data, int verboseLevel = 0);

        void Write(uint startBlock, uint blockCount, byte[] data, SPIWriteModes mode = SPIWriteModes.None, int verboseLevel = 0);

        void Write(uint startBlock, uint blockCount, string file, SPIWriteModes mode = SPIWriteModes.None, int verboseLevel = 0);

        #endregion Write

        #region Read

        byte[] ReadBlock(uint blockID, int verboseLevel = 0);

        byte[] Read(uint startBlock, uint blockCount, int verboseLevel = 0);

        void Read(uint startBlock, uint blockCount, string file, int verboseLevel = 0);

        void Read(uint startBlock, uint blockCount, IEnumerable<string> files, int verboseLevel = 0);

        #endregion Read
    }

    [Flags] public enum SPIWriteModes {
        None = 0,
        AddSpare = 1,
        CorrectSpare = 2,
        EraseFirst = 4,
        VerifyAfter = 8,
        
    }
}