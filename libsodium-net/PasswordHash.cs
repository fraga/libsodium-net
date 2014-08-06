using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Sodium
{
  public class PasswordHash
  {
    public const uint SCRYPT_SALSA208_SHA256_BYTES = 102U;

    public static string HashSalsa208Sha256(string password, string salt, long opsLimit, int memLimit)
    {
      byte[] output = HashSalsa208Sha256(Utilities.HexToBinary(password), Utilities.HexToBinary(salt), opsLimit, memLimit);

      return Utilities.BinaryToHex(output);
    }

    public static byte[] HashSalsa208Sha256(byte[] password, byte[] salt, long opsLimit, int memLimit)
    {
      if (password == null || salt == null)
        throw new ArgumentNullException("Password and salt cannot be null");

      if (opsLimit <= 0 || memLimit <= 0)
        throw new ArgumentException("opsLimit or memLimit cannot be zero or negative");

      byte[] buffer = new byte[password.LongLength];

      int ret = 0;

      if (SodiumCore.Is64)
        ret = _SCRYPTX_SALSA208_SHA256_X64(buffer, buffer.LongLength, password, password.LongLength, salt, opsLimit, memLimit);
      else
        ret = _SCRYPTX_SALSA208_SHA256_X86(buffer, buffer.LongLength, password, password.LongLength, salt, opsLimit, memLimit);

      if (ret != 0)
        throw new Exception(String.Format("Internal error, check for proper libsodium version - {0}", SodiumCore.SodiumVersionString));

      return buffer;
    }

    [DllImport(SodiumCore.LIBRARY_X64, EntryPoint = "crypto_pwhash_scryptxsalsa208sha256", CallingConvention = CallingConvention.Cdecl)]
    private static extern int _SCRYPTX_SALSA208_SHA256_X64(byte[] buffer, long bufferLen, byte[] password, long passwordLen, byte[] salt, long opsLimit, int memLimit);

    [DllImport(SodiumCore.LIBRARY_X64, EntryPoint = "crypto_pwhash_scryptxsalsa208sha256_str", CallingConvention = CallingConvention.Cdecl)]
    private static extern int _SCRYPTX_SALSA208_SHA256_STR_X64(byte[] buffer, byte[] password, long passwordLen, long opsLimit, int memLimit);

    [DllImport(SodiumCore.LIBRARY_X64, EntryPoint = "crypto_pwhash_scryptxsalsa208sha256_str_verify", CallingConvention = CallingConvention.Cdecl)]
    private static extern int _SCRYPTX_SALSA208_SHA256_VERIFY_X64(byte[] buffer, byte[] password, long passLength);

    [DllImport(SodiumCore.LIBRARY_X86, EntryPoint = "crypto_pwhash_scryptxsalsa208sha256", CallingConvention = CallingConvention.Cdecl)]
    private static extern int _SCRYPTX_SALSA208_SHA256_X86(byte[] buffer, long bufferLen, byte[] password, long passwordLen, byte[] salt, long opsLimit, int memLimit);

    [DllImport(SodiumCore.LIBRARY_X86, EntryPoint = "crypto_pwhash_scryptxsalsa208sha256_str", CallingConvention = CallingConvention.Cdecl)]
    private static extern int _SCRYPTX_SALSA208_SHA256_STR_X86(byte[] buffer, byte[] password, long passwordLen, long opsLimit, int memLimit);

    [DllImport(SodiumCore.LIBRARY_X86, EntryPoint = "crypto_pwhash_scryptxsalsa208sha256_str_verify", CallingConvention = CallingConvention.Cdecl)]
    private static extern int _SCRYPTX_SALSA208_SHA256_VERIFY_X86(byte[] buffer, byte[] password, long passLength);
  }
}

