﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StrawberryShake;
using StrawberryShake.Configuration;
using StrawberryShake.Http;
using StrawberryShake.Http.Pipelines;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Serializers;
using StrawberryShake.Transport;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public static partial class AlbumClientServiceCollectionExtensions
    {
        private const string _clientName = "AlbumClient";

        public static IOperationClientBuilder AddAlbumClient(
            this IServiceCollection serviceCollection)
        {
            if (serviceCollection is null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddSingleton<IAlbumClient, AlbumClient>();

            serviceCollection.AddSingleton<IOperationExecutorFactory>(sp =>
                new HttpOperationExecutorFactory(
                    _clientName,
                    sp.GetRequiredService<IHttpClientFactory>().CreateClient,
                    sp.GetRequiredService<IClientOptions>().GetOperationPipeline<IHttpOperationContext>(_clientName),
                    sp.GetRequiredService<IClientOptions>().GetOperationFormatter(_clientName),
                    sp.GetRequiredService<IClientOptions>().GetResultParsers(_clientName)));

            IOperationClientBuilder builder = serviceCollection.AddOperationClientOptions(_clientName)
                .AddValueSerializer(() => new StatusValueSerializer())
                .AddValueSerializer(() => new GeoCoordinateDirectionValueSerializer())
                .AddValueSerializer(() => new ModelSortDirectionValueSerializer())
                .AddValueSerializer(() => new ModelAttributeTypesValueSerializer())
                .AddValueSerializer(() => new ModelPhotoFilterInputSerializer())
                .AddValueSerializer(() => new ModelIDInputSerializer())
                .AddValueSerializer(() => new ModelStringInputSerializer())
                .AddValueSerializer(() => new ModelStatusInputSerializer())
                .AddValueSerializer(() => new ModelSizeInputSerializer())
                .AddResultParser(serializers => new GetAlbumResultParser(serializers))
                .AddResultParser(serializers => new ListAlbumsResultParser(serializers))
                .AddResultParser(serializers => new GetPhotoResultParser(serializers))
                .AddResultParser(serializers => new ListPhotosResultParser(serializers))
                .AddResultParser(serializers => new ListPhotosByAlbumUploadTimeResultParser(serializers))
                .AddOperationFormatter(serializers => new JsonOperationFormatter(serializers))
                .AddHttpOperationPipeline(b => b.UseHttpDefaultPipeline());

            serviceCollection.TryAddSingleton<IOperationExecutorPool, OperationExecutorPool>();
            return builder;
        }

    }
}
