using ProcessMemory;
using SRTPluginProviderRE4.Structs.GameStructs;
using System;
using System.Diagnostics;

namespace SRTPluginProviderRE4
{
    internal unsafe class GameMemoryRE4Scanner : IDisposable
    {

        // Variables
        private ProcessMemoryHandler memoryAccess;
        private GameMemoryRE4 gameMemoryValues;
        public bool HasScanned;
        public bool ProcessRunning => memoryAccess != null && memoryAccess.ProcessRunning;
        public int ProcessExitCode => (memoryAccess != null) ? memoryAccess.ProcessExitCode : 0;

        // Pointer Address Variables
        private int* pointerAddressMoney;
        private int* pointerAddressHP;
        private int* pointerAddressMaxHP;
        private int* pointerAddressHP2;
        private int* pointerAddressMaxHP2;

        // Pointer Classes
        private IntPtr BaseAddress { get; set; }

        internal GameMemoryRE4Scanner(Process process = null)
        {
            gameMemoryValues = new GameMemoryRE4();
            if (process != null)
                Initialize(process);
        }

        internal unsafe void Initialize(Process process)
        {
            if (process == null)
                return; // Do not continue if this is null.

            SelectPointerAddresses();

            int pid = GetProcessId(process).Value;
            memoryAccess = new ProcessMemoryHandler(pid);
            if (ProcessRunning)
            {
                BaseAddress = NativeWrappers.GetProcessBaseAddress(pid, PInvoke.ListModules.LIST_MODULES_32BIT); // Bypass .NET's managed solution for getting this and attempt to get this info ourselves via PInvoke since some users are getting 299 PARTIAL COPY when they seemingly shouldn't.
            }
        }

        private void SelectPointerAddresses()
        {
            pointerAddressMoney = (int*)0xA3F708;
            pointerAddressHP = (int*)0xA3F714;
            pointerAddressMaxHP = (int*)0xA3F716;
            pointerAddressHP2 = (int*)0xA3F718;
            pointerAddressMaxHP2 = (int*)0xA3F71A;
            //pointerAddressIGT = (int*)0xA3FA6C; // Cut Performance In Half Advise Against it.
        }

        internal void UpdatePointers()
        {
        }

        internal unsafe IGameMemoryRE4 Refresh()
        {
            bool success;

            // Money
            fixed (int* p = &gameMemoryValues._money)
                success = memoryAccess.TryGetIntAt(pointerAddressMoney, p);

            // Leon HP
            fixed (short* p = &gameMemoryValues._playerCurrentHealth)
                success = memoryAccess.TryGetShortAt(pointerAddressHP, p);

            fixed (short* p = &gameMemoryValues._playerMaxHealth)
                success = memoryAccess.TryGetShortAt(pointerAddressMaxHP, p);

            // Ashley HP
            fixed (short* p = &gameMemoryValues._playerCurrentHealth2)
                success = memoryAccess.TryGetShortAt(pointerAddressHP2, p);

            fixed (short* p = &gameMemoryValues._playerMaxHealth2)
                success = memoryAccess.TryGetShortAt(pointerAddressMaxHP2, p);

            HasScanned = true;
            return gameMemoryValues;
        }

        private int? GetProcessId(Process process) => process?.Id;

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls


        private unsafe bool SafeReadByteArray(IntPtr address, int size, out byte[] readBytes)
        {
            readBytes = new byte[size];
            fixed (byte* p = readBytes)
            {
                return memoryAccess.TryGetByteArrayAt(address, size, p);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    if (memoryAccess != null)
                        memoryAccess.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~REmake1Memory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}