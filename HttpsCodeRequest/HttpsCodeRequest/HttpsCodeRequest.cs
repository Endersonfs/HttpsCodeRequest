using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpsCodeRequest
{
    //variables necesarias
    
    /// <summary>
    /// Enum donde estan todos los codigo con su descripcion
    /// </summary>
    public enum HttpsCode
    {
        #region Informational Responses
        [Description("The server has received the request headers and the client should proceed to send the request body (in the case of a request for which a body needs to be sent; for example, a POST request). Sending a large request body to a server after a request has been rejected for inappropriate headers would be inefficient. To have a server check the request's headers, a client must send Expect: 100-continue as a header in its initial request and receive a 100 Continue status code in response before sending the body. If the client receives an error code such as 403 (Forbidden) or 405 (Method Not Allowed) then it should not send the request's body. The response 417 Expectation Failed indicates that the request should be repeated without the Expect header as it indicates that the server does not support expectations (this is the case, for example, of HTTP/1.0 servers).")]
        Continue = 100,
        
        [Description("The requester has asked the server to switch protocols and the server has agreed to do so.")]
        SwitchingProtocols = 101,
        
        [Description("A WebDAV request may contain many sub-requests involving file operations, requiring a long time to complete the request. This code indicates that the server has received and is processing the request, but no response is available yet. [3] This prevents the client from timing out and assuming the request was lost. The status code is deprecated.")]
        Processing = 102,
        
        [Description("Used to return some response headers before final HTTP message.")]
        EarlyHints = 103,
        #endregion

        #region Success Responses
        [Description("Standard response for successful HTTP requests. The actual response will depend on the request method used. In a GET request, the response will contain an entity corresponding to the requested resource. In a POST request, the response will contain an entity describing or containing the result of the action.")]
        OK = 200,
        
        [Description("The request has been fulfilled, resulting in the creation of a new resource.")]
        Created = 201,
        
        [Description("The request has been accepted for processing, but the processing has not been completed. The request might or might not be eventually acted upon, and may be disallowed when processing occurs.")]
        Accepted = 202,
        
        [Description("The server is a transforming proxy (e.g. a Web accelerator) that received a 200 OK from its origin, but is returning a modified version of the origin's response.")]
        NonAuthoritativeInformation = 203,
        
        [Description("The server successfully processed the request, and is not returning any content.")]
        NoContent = 204,
        
        [Description("The server successfully processed the request, asks that the requester reset its document view, and is not returning any content.")]
        ResetContent = 205,
        
        [Description("The server is delivering only part of the resource (byte serving) due to a range header sent by the client. The range header is used by HTTP clients to enable resuming of interrupted downloads, or split a download into multiple simultaneous streams.")]
        PartialContent = 206,
        
        [Description("The message body that follows is by default an XML message and can contain a number of separate response codes, depending on how many sub-requests were made")]
        MultiStatus = 207,
        
        [Description("The members of a DAV binding have already been enumerated in a preceding part of the (multistatus) response, and are not being included again.")]
        AlreadyReported = 208,
        
        [Description("The server has fulfilled a request for the resource, and the response is a representation of the result of one or more instance-manipulations applied to the current instance.")]
        IMUsed = 226,
        #endregion

        #region Redirection Responses
        [Description("Equivalent to HTTP status 300. Ambiguous indicates that the requested information has multiple representations. The default action is to treat this status as a redirect and follow the contents of the Location header associated with this response. Ambiguous is a synonym for MultipleChoices.")]
        Ambiguous = 300,
        
        [Description("This and all future requests should be directed to the given URI.")]
        MultipleChoices = 300,
        
        [Description("Equivalent to HTTP status 301. Moved indicates that the requested information has been moved to the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will use the GET method. Moved is a synonym for MovedPermanently.")]
        Moved = 301,
        
        [Description("This and all future requests should be directed to the given")]
        MovedPermanently = 301,
        
        [Description("The 302 (Found) status code indicates that the target resource resides temporarily under a different URI. Since the redirection might be altered on occasion, the client ought to continue to use the target URI for future requests.\r\n\r\n")]
        Found = 302,
        
        [Description("Equivalent to HTTP status 302. Redirect indicates that the requested information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will use the GET method. Redirect is a synonym for Found.")]
        Redirect = 302,
        
        [Description("Equivalent to HTTP status 303. RedirectMethod automatically redirects the client to the URI specified in the Location header as the result of a POST. The request to the resource specified by the Location header will be made with a GET. RedirectMethod is a synonym for SeeOther")]
        RedirectMethod = 303,
        
        [Description("Equivalent to HTTP status 303. RedirectMethod automatically redirects the client to the URI specified in the Location header as the result of a POST. The request to the resource specified by the Location header will be made with a GET. RedirectMethod is a synonym for SeeOther")]
        SeeOther = 303,
        
        [Description("Indicates that the resource has not been modified since the version specified by the request headers If-Modified-Since or If-None-Match. In such case, there is no need to retransmit the resource since the client still has a previously-downloaded copy.")]
        NotModified = 304,
        
        [Description("Equivalent to HTTP status 305. UseProxy indicates that the request should use the proxy server at the URI specified in the Location header.")]
        UseProxy = 305,
        
        [Description("Equivalent to HTTP status 306. Unused is a proposed extension to the HTTP/1.1 specification that is not fully specified.")]
        Unused = 306,
        
        [Description("Equivalent to HTTP status 307. RedirectKeepVerb indicates that the request information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will also use the POST method. RedirectKeepVerb is a synonym for TemporaryRedirect.")]
        RedirectKeepVerb = 307,
        
        [Description("Equivalent to HTTP status 307. TemporaryRedirect indicates that the request information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will also use the POST method. TemporaryRedirect is a synonym for RedirectKeepVerb.")]
        TemporaryRedirect = 307,
        
        [Description("Equivalent to HTTP status 308. PermanentRedirect indicates that the request information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will also use the POST method.")]
        PermanentRedirect = 308,
        #endregion

        #region Client errors Responses
        [Description("The 400 (Bad Request) status code indicates that the server cannot or will not process the request due to something that is perceived to be a client error (e.g., malformed request syntax, invalid request message framing, or deceptive request routing).\r\n\r\n")]
        BadRequest = 400,

        [Description("Similar to 403 Forbidden, but specifically for use when authentication is required and has failed or has not yet been provided. The response must include a WWW-Authenticate header field containing a challenge applicable to the requested resource. See Basic access authentication and Digest access authentication. 401 semantically means unauthorised, the user does not have valid authentication credentials for the target resource.\r\nSome sites incorrectly issue HTTP 401 when an IP address is banned from the website (usually the website domain) and that specific address is refused permission to access a website.")]
        Unauthorized = 401,

        [Description("Reserved for future use. The original intention was that this code might be used as part of some form of digital cash or micropayment scheme, as proposed, for example, by GNU Taler,[14] but that has not yet happened, and this code is not widely used. Google Developers API uses this status if a particular developer has exceeded the daily limit on requests.[15] Sipgate uses this code if an account does not have sufficient funds to start a call.[16] Shopify uses this code when the store has not paid their fees and is temporarily disabled.[17] Stripe uses this code for failed payments where parameters were correct, for example blocked fraudulent payments")]
        PaymentRequired = 402,

        [Description("The request contained valid data and was understood by the server, but the server is refusing action. This may be due to the user not having the necessary permissions for a resource or needing an account of some sort, or attempting a prohibited action (e.g. creating a duplicate record where only one is allowed). This code is also typically used if the request provided authentication by answering the WWW-Authenticate header field challenge, but the server did not accept that authentication. The request should not be repeated.")]
        Forbidden = 403,

        [Description("The requested resource could not be found but may be available in the future. Subsequent requests by the client are permissible.")]
        NotFound = 404,

        [Description("A request method is not supported for the requested resource; for example, a GET request on a form that requires data to be presented via POST, or a PUT request on a read-only resource.")]
        MethodNotAllowed = 405,

        [Description("The requested resource is capable of generating only content not acceptable according to the Accept headers sent in the request. See Content negotiation.")]
        NotAcceptable = 406,

        [Description("The client must first authenticate itself with the proxy.")]
        ProxyAuthenticationRequired = 407,

        [Description("The server timed out waiting for the request. According to HTTP specifications: The client did not produce a request within the time that the server was prepared to wait. The client MAY repeat the request without modifications at any later time.")]
        RequestTimeout = 408,

        [Description("Indicates that the request could not be processed because of conflict in the current state of the resource, such as an edit conflict between multiple simultaneous updates.")]
        Conflict = 409,

        [Description("Indicates that the resource requested was previously in use but is no longer available and will not be available again. This should be used when a resource has been intentionally removed and the resource should be purged. Upon receiving a 410 status code, the client should not request the resource in the future. Clients such as search engines should remove the resource from their indices. Most use cases do not require clients and search engines to purge the resource, and a 404 Not Found may be used instead.")]
        Gone = 410,

        [Description("The request did not specify the length of its content, which is required by the requested resource.")]
        LengthRequired = 411,

        [Description("The server does not meet one of the preconditions that the requester put on the request header fields.")]
        PreconditionFailed = 412,

        [Description("The request is larger than the server is willing or able to process. Previously called Request Entity Too Large in RFC 2616.")]
        RequestEntityTooLarge = 413,

        [Description("The URI provided was too long for the server to process. Often the result of too much data being encoded as a query-string of a GET request, in which case it should be converted to a POST request. Called Request-URI Too Long previously in RFC 2616.")]
        RequestUriTooLong = 414,

        [Description("The request entity has a media type which the server or resource does not support. For example, the client uploads an image as image/svg+xml, but the server requires that images use a different format.")]
        UnsupportedMediaType = 415,

        [Description("The client has asked for a portion of the file (byte serving), but the server cannot supply that portion. For example, if the client asked for a part of the file that lies beyond the end of the file. Called Requested Range Not Satisfiable previously RFC 2616")]
        RequestedRangeNotSatisfiable = 416,

        [Description("The server cannot meet the requirements of the Expect request-header field.")]
        ExpectationFailed = 417,

        [Description("The server refuses to try to make coffee with a kettle.")]
        Iamateapot = 418,

        [Description("The request was directed at a server that is not able to produce a response (for example because of connection reuse).")]
        MisdirectedRequest = 421,
        
        [Description("The request was well-formed but was unable to be followed due to semantic errors.")]
        UnprocessableEntity = 422,
        
        [Description("The resource that is being accessed is locked.")]
        Locked = 423,
        
        [Description("The request failed because it depended on another request and that request failed (e.g., a PROPPATCH).")]
        FailedDependency = 424,
        
        [Description("The request failed because it depended on another request and that request failed (e.g., a PROPPATCH).")]
        TooEarly = 425,
        
        [Description("Indicates that the server is unwilling to risk processing a request that might be replayed.")]
        UpgradeRequired = 426,
        
        [Description("The origin server requires the request to be conditional. Intended to prevent the 'lost update' problem, where a client GETs a resource's state, modifies it, and PUTs it back to the server, when meanwhile a third party has modified the state on the server, leading to a conflict")]
        PreconditionRequired = 428,
        
        [Description("The user has sent too many requests in a given amount of time. Intended for use with rate-limiting schemes")]
        TooManyRequests = 429,
        
        [Description("The server is unwilling to process the request because either an individual header field, or all the header fields collectively, are too large.")]
        RequestHeaderFieldsTooLarge = 431,
        
        [Description("A server operator has received a legal demand to deny access to a resource or to a set of resources that includes the requested resource.")]
        UnavailableForLegalReasons = 451,
        #endregion

        #region Server errors Responses
        [Description("A generic error message, given when an unexpected condition was encountered and no more specific message is suitable.")]
        InternalServerError = 500,
        
        [Description("The server either does not recognize the request method, or it lacks the ability to fulfil the request. Usually this implies future availability (e.g., a new feature of a web-service API)")]
        NotImplemented = 501,
        
        [Description("The server was acting as a gateway or proxy and received an invalid response from the upstream server.")]
        BadGateway = 502,
        
        [Description("The server cannot handle the request (because it is overloaded or down for maintenance). Generally, this is a temporary state.")]
        ServiceUnavailable = 503,
        
        [Description("The server was acting as a gateway or proxy and did not receive a timely response from the upstream server.")]
        GatewayTimeout = 504,
        
        [Description("The server does not support the HTTP version used in the request.")]
        HttpVersionNotSupported = 505,
        
        [Description("Transparent content negotiation for the request results in a circular reference.")]
        VariantAlsoNegotiates = 506,
        
        [Description("The server is unable to store the representation needed to complete the request.")]
        InsufficientStorage = 507,
        
        [Description("The server detected an infinite loop while processing the request (sent instead of 208 Already Reported).")]
        LoopDetected = 508,
        
        [Description("Further extensions to the request are required for the server to fulfil it.")]
        NotExtended = 510,
        
        [Description("he client needs to authenticate to gain network access. Intended for use by intercepting proxies used to control access to the network (e.g., captive portals used to require agreement to Terms of Service before granting full Internet access via a Wi-Fi hotspot).")]
        NetworkAuthenticationRequired = 511
        #endregion
    }
    /// <summary>
    /// Clase para los HttpsCode, encargada de devolver la descripcion de los codigos
    /// </summary>
    public static class HttpStatusCode
    {
        /// <summary>
        /// Metodo para tener la descripcion de los HttpsCode.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value) 
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attr.Length == 0 ? value.ToString() : (attr[0] as DescriptionAttribute).Description;
        }

        /// <summary>
        /// Metodo para tener la descripcion de los HttpsCode, este metedo recibe un codigo para validar el mismo y retornar la descripcion.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescriptionByCode(Enum code)
        {
            try
            {
                var field = code.GetType().GetField(code.ToString());
                var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attr.Length == 0 ? code.ToString() : (attr[0] as DescriptionAttribute).Description;
            }
            catch(Exception ex) 
            {
                return ex.Message;
            }
        }
    }
}
