using System;
using System.Collections.Generic;
using Android.Util;

namespace Saplin.CPDT.Droid.CachePurger
{
    public class Common
    {
        static readonly string TAG = typeof(PurgeService).FullName;
        public const long blockSize = 16 * 1024 * 1024;
        public const long defaultMemCapacity = (long)128 * 1024 * 1024 * 1024;
        private static readonly Random rand = new Random();

        public static byte[] AllocBlock()
        {
            byte[] block = null;

            block = new byte[blockSize];

            Array.Clear(block, 0, block.Length);

            var randN = (byte)rand.Next();

            for (int i = 0; i < block.Length; i += 128)
                block[i] = randN++;

            return block;
        }

        public static List<byte[]> AllocNBlocks(int n, Func<bool> breakCalled = null)
        {
            var blocks = new List<byte[]>();
            byte[] block = null;

            for (var i = 0; i < n; i++)
            {
                if (breakCalled != null && breakCalled()) break;
                Log.Debug(TAG, "AllockBlock: " + i);

                block = AllocBlock();

                if (block != null) blocks.Add(block);
            }

            return blocks;
        }
    }
}
