using System;
using Amazon.CDK;
using Amazon.CDK.AWS.AppSync;
using Amazon.CDK.AWS.DynamoDB;
using Amazon.CDK.AWS.IAM;
using Attribute = Amazon.CDK.AWS.DynamoDB.Attribute;

namespace ImageRecognitionInfrastructure
{

    public class BuildPhotoStack : Stack
    {

        internal const string PHOTO_TABLE_STREAM_ARN_EXPORT = "PhotoTableStreamArn";

        internal const string PHOTO_TABLE_DATASOURCE_NAME_EXPORT = "PhotoDataSourceName";

        internal const string PHOTO_TABLE_NAME_EXPORT = "PhotoTableName";


        internal BuildPhotoStack(Construct scope, string id = "Image-Recognition-Photo-Stack", IStackProps props = null) : base(scope, id, props)
        {
            try
            {

                var photoTable = new Table(this, "PhotoTable", new TableProps
                {
                    PartitionKey = new Attribute { Name = "id", Type = AttributeType.STRING },
                    BillingMode = BillingMode.PAY_PER_REQUEST,
                    RemovalPolicy = RemovalPolicy.DESTROY,
                    Stream = StreamViewType.NEW_AND_OLD_IMAGES
                });

                photoTable.AddGlobalSecondaryIndex(new GlobalSecondaryIndexProps
                {
                    IndexName = "byAlbumUploadTime",
                    PartitionKey = new Attribute { Name = "albumId", Type = AttributeType.STRING },
                    SortKey = new Attribute { Name = "uploadTime", Type = AttributeType.STRING },
                    ProjectionType = ProjectionType.ALL
                });

                string appSyncName = Fn.ImportValue(BuildAppSyncStack.GRAPHQL_API_ID_EXPORT);
                var graphqlAPI = GraphqlApi.FromGraphqlApiAttributes(this, "Existing-Graph-API", new GraphqlApiAttributes { GraphqlApiId = appSyncName });

                var photoTableDataSource = graphqlAPI.AddDynamoDbDataSource("PhotoTable", photoTable);

                photoTableDataSource.CreateResolver(new ResolverProps
                {
                    TypeName = "Query",
                    FieldName = "getPhoto",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Query.getPhoto.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Query.getPhoto.res.vtl"),
                });

                photoTableDataSource.CreateResolver(new ResolverProps
                {
                    TypeName = "Query",
                    FieldName = "listPhotos",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Query.listPhotos.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Query.listPhotos.res.vtl"),
                });

                photoTableDataSource.CreateResolver(new ResolverProps
                {
                    TypeName = "Mutation",
                    FieldName = "createPhoto",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.createPhoto.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.createPhoto.res.vtl"),
                });

                photoTableDataSource.CreateResolver(new ResolverProps
                {
                    TypeName = "Mutation",
                    FieldName = "updatePhoto",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.updatePhoto.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.updatePhoto.res.vtl"),
                });

                photoTableDataSource.CreateResolver(new ResolverProps
                {
                    TypeName = "Mutation",
                    FieldName = "deletePhoto",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.deletePhoto.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.deletePhoto.res.vtl"),
                });


                photoTableDataSource.CreateResolver(new ResolverProps
                {
                    TypeName = "Query",
                    FieldName = "listPhotosByAlbumUploadTime",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Query.listPhotosByAlbumUploadTime.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Query.listPhotosByAlbumUploadTime.res.vtl"),
                });

                photoTableDataSource.CreateResolver(new ResolverProps
                {
                    TypeName = "Subscription",
                    FieldName = "onCreatePhoto",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Subscription.onCreatePhoto.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Subscription.onCreatePhoto.res.vtl"),
                });

                photoTableDataSource.CreateResolver(new ResolverProps
                {
                    TypeName = "Subscription",
                    FieldName = "onUpdatePhoto",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Subscription.onUpdatePhoto.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Subscription.onUpdatePhoto.res.vtl"),
                });

                photoTableDataSource.CreateResolver(new ResolverProps
                {
                    TypeName = "Subscription",
                    FieldName = "onDeletePhoto",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Subscription.onDeletePhoto.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Subscription.onDeletePhoto.res.vtl"),
                });


                new CfnOutput(this, "PhotoTableStreamArn", new CfnOutputProps
                {
                    Value = photoTable.TableStreamArn,
                    ExportName = PHOTO_TABLE_STREAM_ARN_EXPORT
                });

                new CfnOutput(this, "PhotoTableDataSourceName", new CfnOutputProps
                {
                    Value = photoTableDataSource.Name,
                    ExportName = PHOTO_TABLE_DATASOURCE_NAME_EXPORT
                });

                new CfnOutput(this, "PhotoTableName", new CfnOutputProps
                {
                    Value = photoTable.TableName,
                    ExportName = PHOTO_TABLE_NAME_EXPORT
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}