using System;
using Amazon.CDK;
using Amazon.CDK.AWS.AppSync;
using Amazon.CDK.AWS.DynamoDB;
using Amazon.CDK.AWS.IAM;
using Attribute = Amazon.CDK.AWS.DynamoDB.Attribute;

namespace ImageRecognitionInfrastructure
{

    public class BuildAlbumStack : Stack
    {

        internal const string ALBUM_TABLE_STREAM_ARN_EXPORT = "AlbumTableStreamArn";

        internal const string ALBUM_TABLE_DATASOURCE_NAME_EXPORT = "AlbumDataSourceName";

        internal const string ALBUM_TABLE_NAME_EXPORT = "AlbumTableName";


        internal BuildAlbumStack(Construct scope, string id="Image-Recognition-2-Album-Stack", IStackProps props = null) : base(scope, id, props)
        {
            try{
                var albumTable = new Table(this, "AlbumTable", new TableProps {
                    PartitionKey = new Attribute { Name = "id",  Type = AttributeType.STRING },
                    BillingMode = BillingMode.PAY_PER_REQUEST,
                    RemovalPolicy = RemovalPolicy.DESTROY,
                    Stream = StreamViewType.NEW_AND_OLD_IMAGES
                });

                string appSyncName = Fn.ImportValue(BuildAppSyncStack.GRAPHQL_API_ID_EXPORT);
                var graphqlAPI = GraphqlApi.FromGraphqlApiAttributes(this, "Existing-Graph-API", new GraphqlApiAttributes {GraphqlApiId = appSyncName});

                var albumTableDataSource = graphqlAPI.AddDynamoDbDataSource("AlbumTable", albumTable);

                albumTableDataSource.CreateResolver(new ResolverProps{
                    TypeName = "Query",
                    FieldName = "getAlbum",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Query.getAlbum.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Query.getAlbum.res.vtl"),
                });

                albumTableDataSource.CreateResolver(new ResolverProps{
                    TypeName = "Query",
                    FieldName = "listAlbums",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Query.listAlbums.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Query.listAlbums.res.vtl"),
                });

                albumTableDataSource.CreateResolver(new ResolverProps{
                    TypeName = "Mutation",
                    FieldName = "createAlbum",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.createAlbum.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.createAlbum.res.vtl"),
                });

                albumTableDataSource.CreateResolver(new ResolverProps{
                    TypeName = "Mutation",
                    FieldName = "updateAlbum",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.updateAlbum.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.updateAlbum.res.vtl"),
                });

                albumTableDataSource.CreateResolver(new ResolverProps{
                    TypeName = "Mutation",
                    FieldName = "deleteAlbum",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.deleteAlbum.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.deleteAlbum.res.vtl"),
                });

                albumTableDataSource.CreateResolver(new ResolverProps{
                    TypeName = "Subscription",
                    FieldName = "onCreateAlbum",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Subscription.onCreateAlbum.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Subscription.onCreateAlbum.res.vtl"),
                });

                albumTableDataSource.CreateResolver(new ResolverProps{
                    TypeName = "Subscription",
                    FieldName = "onUpdateAlbum",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Subscription.onUpdateAlbum.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Subscription.onUpdateAlbum.res.vtl"),
                });

                albumTableDataSource.CreateResolver(new ResolverProps{
                    TypeName = "Subscription",
                    FieldName = "onDeleteAlbum",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Subscription.onDeleteAlbum.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Subscription.onDeleteAlbum.res.vtl"),
                });

                albumTableDataSource.CreateResolver(new ExtendedResolverProps{
                    TypeName = "Photo",
                    FieldName = "album",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Photo.album.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Photo.album.res.vtl")
                });

                new CfnOutput(this, "AlbumTableStreamArn", new CfnOutputProps{
                    Value = albumTable.TableStreamArn,
                    ExportName = ALBUM_TABLE_STREAM_ARN_EXPORT
                });

                new CfnOutput(this, "AlbumTableDataSourceName", new CfnOutputProps{
                    Value = albumTableDataSource.Name,
                    ExportName = ALBUM_TABLE_DATASOURCE_NAME_EXPORT
                });

                new CfnOutput(this, "AlbumTableName", new CfnOutputProps{
                    Value = albumTable.TableName,
                    ExportName = ALBUM_TABLE_NAME_EXPORT
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}