using System;
using Amazon.CDK;
using Amazon.CDK.AWS.AppSync;
using Amazon.CDK.AWS.DynamoDB;
using Amazon.CDK.AWS.IAM;
using Attribute = Amazon.CDK.AWS.DynamoDB.Attribute;

namespace ImageRecognitionInfrastructure
{

    public class BuildCustomResourceStack : Stack
    {
        internal BuildCustomResourceStack(Construct scope, string id="Image-Recognition-4-Custom-Stack", IStackProps props = null) : base(scope, id, props)
        {
            try{
                string appSyncName = Fn.ImportValue(BuildAppSyncStack.GRAPHQL_API_ID_EXPORT);
                var graphqlAPI = GraphqlApi.FromGraphqlApiAttributes(this, "Existing-Graph-API", new GraphqlApiAttributes {GraphqlApiId = appSyncName});

                var sfnProxyDataSource = graphqlAPI.AddHttpDataSource
                    (
                        "SfnProxyDataSource", 
                        "https://states." + Region + ".amazonaws.com/",
                        new HttpDataSourceOptions{
                            AuthorizationConfig = new AwsIamConfig(){
                                SigningRegion = Region,
                                SigningServiceName = "states"
                            }
                        }
                    );

                PolicyStatement sfnPolicy = new PolicyStatement( new PolicyStatementProps{
                    Effect = Effect.ALLOW,
                    Actions = new string[]{"states:StartExecution", "states:DescribeExecution"},
                    Resources = new string[]{"*"}
                });


                sfnProxyDataSource.GrantPrincipal.AddToPrincipalPolicy(sfnPolicy);

                sfnProxyDataSource.CreateResolver(new ResolverProps{
                    TypeName = "Mutation",
                    FieldName = "startSfnExecution",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.startSfnExecution.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Mutation.startSfnExecution.res.vtl"),
                });


                sfnProxyDataSource.CreateResolver(new ResolverProps{
                    TypeName = "Query",
                    FieldName = "checkSfnStatus",
                    RequestMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Query.checkSfnStatus.req.vtl"),
                    ResponseMappingTemplate = MappingTemplate.FromFile("src/ImageRecognitionInfrastructure/API/resolvers/Query.checkSfnStatus.res.vtl"),
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}