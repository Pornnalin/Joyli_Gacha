using System;
using System.Text;
using System.Security.Cryptography;
//using Org.BouncyCastle.Crypto;
//using Org.BouncyCastle.OpenSsl;
//using Org.BouncyCastle.Security;
//using Jwt = System.IdentityModel.Tokens.Jwt;
using UnityEngine;
//using Microsoft.IdentityModel.Tokens;
//using Org.BouncyCastle.Crypto.Parameters;
using System.IO;
//using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class Header
{
    public string alg;
    public string typ;
}

public class JWTVerifier
{
    //public static bool VerifyJWT(string jwtToken, string publicKey, ref string respon)
    //{
    //    try
    //    {
    //        // Parse the public key
    //        TextReader reader = new StringReader(publicKey);
    //        AsymmetricKeyParameter key = (AsymmetricKeyParameter)new PemReader(reader).ReadObject();

    //        // Create RSA Parameters from the public key
    //        RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaKeyParameters)key);

    //        // Create a RSA key from the RSAParameters
    //        using (RSA rsa = RSA.Create())
    //        {
    //            rsa.ImportParameters(rsaParams);

    //            // Define the validation parameters
    //            var validationParameters = new TokenValidationParameters
    //            {
    //                RequireSignedTokens = true,
    //                ValidateAudience = true,
    //                ValidAudience = "Moralsverse", // Replace with your audience
    //                ValidateIssuer = true,
    //                ValidIssuer = "https://api.moralsverse.com", // Replace with your issuer
    //                IssuerSigningKey = new RsaSecurityKey(rsa)
    //            };

    //            // Validate the token
    //            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
    //            ClaimsPrincipal claimsPrincipal = handler.ValidateToken(jwtToken, validationParameters, out SecurityToken validatedToken);
    //            respon = "JWT validation success";
    //            // If validation is successful, the token is valid
    //            return true;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.LogError("JWT validation failed: " + ex.Message);
    //        respon = ex.Message;
    //        return false;
    //    }
    //}

    public static byte[] FromBase64Url(string base64Url)
    {
        string padded = base64Url.Length % 4 == 0
            ? base64Url : base64Url + "====".Substring(base64Url.Length % 4);
        string base64 = padded.Replace("_", "/")
                              .Replace("-", "+");
        return Convert.FromBase64String(base64);
    }
}

/*public class JWT
{
    public static string GetJwtUserClass(string claimset)
    {
        // header
        Header header = new Header();
        header.alg = "HS256";
        header.typ = "JWT";

        // encoded header
        var headerSerialized = JsonUtility.ToJson(header);
        var headerBytes = Encoding.UTF8.GetBytes(headerSerialized);
        var headerEncoded = Base64UrlEncode(headerBytes);

        // encoded claimset
        var claimsetSerialized = claimset;//JsonUtility.ToJson(claimset);
        var claimsetBytes = Encoding.UTF8.GetBytes(claimsetSerialized);
        var claimsetEncoded = Base64UrlEncode(claimsetBytes);

        // input
        var input = headerEncoded + "." + claimsetEncoded;
        var messageBytes = Encoding.UTF8.GetBytes(input);

        // certificate
        string client_secret = UserManager.TOKEN_PRIVATE;//"32A8E438272D7998DFFCC59EB5567";

        var encoding = new System.Text.ASCIIEncoding();

        byte[] keyByte = encoding.GetBytes(client_secret);

        var hmacsha256 = new HMACSHA256(keyByte);

        byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

        var signatureEncoded = Base64UrlEncode(hashmessage);

        //var signatureBytes = hmac.SignData(inputBytes, "HS256");

        // jwt
        var jwt = headerEncoded + "." + claimsetEncoded + "." + signatureEncoded;

        return jwt;
    }
    
    //public static string GetJwtUserSave(SendItem claimset)
    //{
    //    // header
    //    Header header = new Header();
    //    header.alg = "HS256";
    //    header.typ = "JWT";

    //    // encoded header
    //    var headerSerialized = JsonUtility.ToJson(header);
    //    var headerBytes = Encoding.UTF8.GetBytes(headerSerialized);
    //    var headerEncoded = Base64UrlEncode(headerBytes);

    //    // encoded claimset
    //    var claimsetSerialized = JsonUtility.ToJson(claimset);
    //    var claimsetBytes = Encoding.UTF8.GetBytes(claimsetSerialized);
    //    var claimsetEncoded = Base64UrlEncode(claimsetBytes);

    //    // input
    //    var input = headerEncoded + "." + claimsetEncoded;
    //    var messageBytes = Encoding.UTF8.GetBytes(input);

    //    // certificate
    //    string client_secret = "ea3dc08d-9af4-4cd2-9833-1a1092e93f87";

    //    var encoding = new System.Text.ASCIIEncoding();

    //    byte[] keyByte = encoding.GetBytes(client_secret);

    //    var hmacsha256 = new HMACSHA256(keyByte);

    //    byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

    //    var signatureEncoded = Base64UrlEncode(hashmessage);

    //    //var signatureBytes = hmac.SignData(inputBytes, "HS256");

    //    // jwt
    //    var jwt = headerEncoded + "." + claimsetEncoded + "." + signatureEncoded;

    //    return jwt;
    //}

    
    //public static string GetJwtAchievement(Achievement claimset)
    //{
    //    // header
    //    Header header = new Header();
    //    header.alg = "HS256";
    //    header.typ = "JWT";

    //    // encoded header
    //    var headerSerialized = JsonUtility.ToJson(header);
    //    var headerBytes = Encoding.UTF8.GetBytes(headerSerialized);
    //    var headerEncoded = Base64UrlEncode(headerBytes);

    //    // encoded claimset
    //    var claimsetSerialized = JsonUtility.ToJson(claimset);
    //    var claimsetBytes = Encoding.UTF8.GetBytes(claimsetSerialized);
    //    var claimsetEncoded = Base64UrlEncode(claimsetBytes);

    //    // input
    //    var input = headerEncoded + "." + claimsetEncoded;
    //    var messageBytes = Encoding.UTF8.GetBytes(input);

    //    // certificate
    //    string client_secret = "ea3dc08d-9af4-4cd2-9833-1a1092e93f87";


    //    var encoding = new System.Text.ASCIIEncoding();

    //    byte[] keyByte = encoding.GetBytes(client_secret);

    //    var hmacsha256 = new HMACSHA256(keyByte);

    //    byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

    //    var signatureEncoded = Base64UrlEncode(hashmessage);

    //    //var signatureBytes = hmac.SignData(inputBytes, "HS256");

    //    // jwt
    //    var jwt = headerEncoded + "." + claimsetEncoded + "." + signatureEncoded;

    //    return jwt;
    //}

    //public static string GetJwt(Submit claimset)
    //{
    //    // header
    //    Header header = new Header();
    //    header.alg = "HS256";
    //    header.typ = "JWT";

    //    // encoded header
    //    var headerSerialized = JsonUtility.ToJson(header);
    //    var headerBytes = Encoding.UTF8.GetBytes(headerSerialized);
    //    var headerEncoded = Base64UrlEncode(headerBytes);

    //    // encoded claimset
    //    var claimsetSerialized = JsonUtility.ToJson(claimset);
    //    var claimsetBytes = Encoding.UTF8.GetBytes(claimsetSerialized);
    //    var claimsetEncoded = Base64UrlEncode(claimsetBytes);

    //    // input
    //    var input = headerEncoded + "." + claimsetEncoded;
    //    var messageBytes = Encoding.UTF8.GetBytes(input);

    //    // certificate
    //    string client_secret = "ea3dc08d-9af4-4cd2-9833-1a1092e93f87";


    //    var encoding = new System.Text.ASCIIEncoding();

    //    byte[] keyByte = encoding.GetBytes(client_secret);

    //    var hmacsha256 = new HMACSHA256(keyByte);

    //    byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

    //    var signatureEncoded = Base64UrlEncode(hashmessage);

    //    //var signatureBytes = hmac.SignData(inputBytes, "HS256");

    //    // jwt
    //    var jwt = headerEncoded + "." + claimsetEncoded + "." + signatureEncoded;

    //    return jwt;
    //}
    
    // from JWT spec
    private static string Base64UrlEncode(byte[] input)
    {
        var output = Convert.ToBase64String(input);
        output = output.Split('=')[0]; // Remove any trailing '='s
        output = output.Replace('+', '-'); // 62nd char of encoding
        output = output.Replace('/', '_'); // 63rd char of encoding
        return output;
    }

    // from JWT spec
    public static byte[] Base64UrlDecode(string input)
    {
        var output = input;
        output = output.Replace('-', '+'); // 62nd char of encoding
        output = output.Replace('_', '/'); // 63rd char of encoding
        switch (output.Length % 4) // Pad with trailing '='s
        {
            case 0: break; // No pad chars in this case
            case 2: output += "=="; break; // Two pad chars
            case 3: output += "="; break; // One pad char
            default: throw new System.Exception("Illegal base64url string!");
        }
        var converted = Convert.FromBase64String(output); // Standard base64 decoder
        return converted;
    }

    public static byte[] Base256UrlDecode(string input)
    {
        string tokenStr = input;//"eyJraWQiOiIxZTlnZGs3IiwiYWxnIjoiUlMyNTYifQ.ewogImlzcyI6ICJodHRwOi8vc2VydmVyLmV4YW1wbGUuY29tIiwKICJzdWIiOiAiMjQ4Mjg5NzYxMDAxIiwKICJhdWQiOiAiczZCaGRSa3F0MyIsCiAibm9uY2UiOiAibi0wUzZfV3pBMk1qIiwKICJleHAiOiAxMzExMjgxOTcwLAogImlhdCI6IDEzMTEyODA5NzAsCiAiY19oYXNoIjogIkxEa3RLZG9RYWszUGswY25YeENsdEEiCn0.XW6uhdrkBgcGx6zVIrCiROpWURs-4goO1sKA4m9jhJIImiGg5muPUcNegx6sSv43c5DSn37sxCRrDZZm4ZPBKKgtYASMcE20SDgvYJdJS0cyuFw7Ijp_7WnIjcrl6B5cmoM6ylCvsLMwkoQAxVublMwH10oAxjzD6NEFsu9nipkszWhsPePf_rM4eMpkmCbTzume-fzZIi5VjdWGGEmzTg32h3jiex-r5WTHbj-u5HL7u_KP3rmbdYNzlzd1xWRYTUs4E8nOTgzAUwvwXkIQhOh5TPcSMBYy6X3E7-_gr9Ue6n4ND7hTFhtjYs3cjNKIA08qm5cpVYFMFMG6PkhzLQ";
        string[] tokenParts = tokenStr.Split('.');

        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.ImportParameters(
          new RSAParameters()
          {
              Modulus = FromBase64Url("w7Zdfmece8iaB0kiTY8pCtiBtzbptJmP28nSWwtdjRu0f2GFpajvWE4VhfJAjEsOcwYzay7XGN0b-X84BfC8hmCTOj2b2eHT7NsZegFPKRUQzJ9wW8ipn_aDJWMGDuB1XyqT1E7DYqjUCEOD1b4FLpy_xPn6oV_TYOfQ9fZdbE5HGxJUzekuGcOKqOQ8M7wfYHhHHLxGpQVgL0apWuP2gDDOdTtpuld4D2LK1MZK99s9gaSjRHE8JDb1Z4IGhEcEyzkxswVdPndUWzfvWBBWXWxtSUvQGBRkuy1BHOa4sP6FKjWEeeF7gm7UMs2Nm2QUgNZw6xvEDGaLk4KASdIxRQ"),
              Exponent = FromBase64Url("AQAB")
          });

        SHA256 sha256 = SHA256.Create();
        byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(tokenParts[0] + '.' + tokenParts[1]));

        RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
        rsaDeformatter.SetHashAlgorithm("SHA256");
        if (rsaDeformatter.VerifySignature(hash, FromBase64Url(tokenParts[2])))
            Debug.Log("Signature is Verified");
        else
            Debug.Log("Not Signature is Verified");

        return hash;
    }

    

    public static int[] GetExpiryAndIssueDate()
    {
        var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        DateTime nowInThailand = DateTime.UtcNow;

        var iat = (int)nowInThailand.Subtract(utc0).TotalSeconds + 25200;
        var exp = (int)nowInThailand.AddMinutes(55).Subtract(utc0).TotalSeconds;

        return new[] { iat, exp };
    }
}*/