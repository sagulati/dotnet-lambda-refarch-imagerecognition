﻿using Amazon.Runtime;
using Amazon.Runtime.Internal.Auth;
using Amazon.SecurityToken.Model;
using Amazon.Util;
using GraphQL;
using GraphQL.Client.Http;
using System;
using System.Net.Http;

namespace s3Trigger
{
    internal class AuthorizedAppSyncHttpRequest : GraphQLHttpRequest
    {
        private IClientConfig _clientConfig;
        private Credentials _credentials;

        public AuthorizedAppSyncHttpRequest(GraphQLRequest request, IClientConfig clientConfig, Credentials credentials) : base(request)
        {
            _clientConfig = clientConfig;
            _credentials = credentials;
        }

        public override HttpRequestMessage ToHttpRequestMessage(GraphQLHttpClientOptions options, GraphQL.Client.Abstractions.IGraphQLJsonSerializer serializer)
        {
            var result = base.ToHttpRequestMessage(options, serializer);

            if (_credentials.SessionToken != null)
                result.Headers.Add(HeaderKeys.XAmzSecurityTokenHeader, _credentials.SessionToken);

            var signingRequest = new AmazonServiceRequest(result, _clientConfig)
            {
                Content = result.Content.ReadAsByteArrayAsync().Result,
            };

            Console.WriteLine(result.Content.ReadAsStringAsync().Result);

            new AWS4Signer().Sign(signingRequest, _clientConfig, null, _credentials.AccessKeyId, _credentials.SecretAccessKey);

            foreach (var header in signingRequest.Headers)
            {
                if (header.Key != HeaderKeys.HostHeader && header.Key != HeaderKeys.XAmzSecurityTokenHeader && header.Key != HeaderKeys.UserAgentHeader)
                    result.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return result;
        }
    }
}