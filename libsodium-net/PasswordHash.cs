using System;
using System.Runtime.InteropServices;

namespace Sodium
{
  public class PasswordHash
  {
    public const uint SCRYPT_SALSA208_SHA256_BYTES = 102U;

    [DllImport(SodiumCore.LIBRARY_X64, EntryPoint = "crypto_pwhash_scryptxsalsa208sha256", CallingConvention = CallingConvention.Cdecl)]
    private static extern int _SCRYPTX_SALSA208_SHA256_X64(byte[] buffer, long bufferLen, byte[] password, long passwordLen, byte[] salt, long opsLimit, int memLimit);

    [DllImport(SodiumCore.LIBRARY_X64, EntryPoint = "crypto_pwhash_scryptxsalsa208sha256_str", CallingConvention = CallingConvention.Cdecl)]
    private static extern int _SCRYPTX_SALSA208_SHA256_STR_X64(byte[] buffer, byte[] password, long passwordLen, long opsLimit, int memLimit);
  }
}

