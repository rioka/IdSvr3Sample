using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace IdSvr3Sample.IdSvr.Configuration
{
  internal class Certificate
  {
    #region Apis
    
    /// <summary>
    /// Gets a certificate
    /// </summary>
    /// <returns></returns>
    public static X509Certificate2 Load()
    {
      var type = MethodBase.GetCurrentMethod().DeclaringType;
      using (var stream = type.Assembly.GetManifestResourceStream(type.Namespace + ".idsrv3test.pfx"))
      {
        return new X509Certificate2(ReadStream(stream), "idsrv3test");
      }
    } 

    #endregion

    #region Internals
    
    /// <summary>
    /// Read as stream as a byte array
    /// </summary>
    /// <param name="input">Input stream</param>
    /// <returns>Returns the content as array of bytes</returns>
    private static byte[] ReadStream(Stream input)
    {
      var buffer = new byte[16 * 1024];
      using (var ms = new MemoryStream())
      {
        int read;
        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        {
          ms.Write(buffer, 0, read);
        }
        return ms.ToArray();
      }
    } 

    #endregion
  }
}
