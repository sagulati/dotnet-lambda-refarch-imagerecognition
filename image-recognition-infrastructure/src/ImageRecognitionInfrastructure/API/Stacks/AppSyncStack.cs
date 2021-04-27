using System;
using System.IO;
using Amazon.CDK;
using Amazon.CDK.AWS.AppSync;
using Amazon.CDK.AWS.DynamoDB;

namespace ImageRecognitionInfrastructure
{

    public class BuildAppSyncStack : Stack
    {

        internal const string GRAPHQL_API_ID_EXPORT = "GraphQLAPIIdOutput";

        internal const string GRAPHQL_API_END_POINT_EXPORT = "GraphQLAPIEndpointOutput";

        public BuildAppSyncStack(Construct scope, string id="Image-Recognition-AppSync-Env-Stack", IStackProps props = null) : base(scope, id, props)
        {
            //TODO: Add Authentication.
            try{
                var api = new GraphqlApi(this, "photoshare", new GraphqlApiProps{
                        Name = "photoshare",
                        Schema = Schema.FromAsset("src/ImageRecognitionInfrastructure/API/schema.graphql"),
                        // AuthorizationConfig = new AuthorizationConfig{
                        //     DefaultAuthorization = new AuthorizationMode(){
                        //         AuthorizationType = AuthorizationType.USER_POOL,

                        //     },
                        //     AdditionalAuthorizationModes = new AuthorizationMode[]{
                        //         new AuthorizationMode(){AuthorizationType =  AuthorizationType.IAM}
                        //     }
                        // }
                });
                

                api.AddNoneDataSource("NONE");

                new CfnOutput(this, "App-Sync-API-ID", new CfnOutputProps{
                    Value = api.ApiId,
                    ExportName = GRAPHQL_API_ID_EXPORT
                });

                new CfnOutput(this, "App-Sync-End-Point", new CfnOutputProps{
                    Value = api.GraphqlUrl,
                    ExportName = GRAPHQL_API_END_POINT_EXPORT
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error " + ex.Message + " " + ex.InnerException);
            }

        }

    }

}