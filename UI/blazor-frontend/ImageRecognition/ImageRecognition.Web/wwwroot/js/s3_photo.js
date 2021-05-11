window.s3 = {

    // Initialize the Amazon Cognito credentials provider
    initialize: (authority, identityPoolId, region, clientId) => {
        
        var userData = sessionStorage.getItem("oidc.user:" + authority + ":" + clientId);

        AWS.config.region = region;

        AWS.config.credentials = new AWS.CognitoIdentityCredentials({
            IdentityPoolId: identityPoolId,
            Logins: {'cognito-idp.us-east-1.amazonaws.com/us-east-1_zw4lsGNVb' : JSON.parse(userData).id_token }
        });

        // var providerName = 'cognito-idp.us-east-1.amazonaws.com/us-east-1_zw4lsGNVb';
        // credentials.params.Logins = credentials.params.Logins || {};
        // credentials.params.Logins["cognito-idp.us-east-1.amazonaws.com/us-east-1_zw4lsGNVb"] = JSON.parse(userData).id_token;
        // // Expire credentials to refresh them on the next request
        //credentials.expired = true;

        //AWS.config.credentials = credentials;   

    },

    getSignedUrl: async (albumBucketName, key) => {
                
        // Create a new service object
        var AWS_S3 = new AWS.S3();
        //     apiVersion: '2006-03-01',
        //     params: { Bucket: albumBucketName }
        // });

        var params = {
            Bucket: albumBucketName,
            Key: key,
            Expires: 100
        };

        var preSignedUrl = await new Promise(( resolve, reject ) => 
            {
                AWS_S3.getSignedUrl('getObject', params, (err, preSignedUrl) => { 
                    err ? reject(err) : resolve(preSignedUrl)
                } );
            });

        // AWS_S3.getSignedUrl('getObject', {
        //     Bucket: albumBucketName,
        //     Key: key,
        //     Expires: 100
        // } );

        console.log(preSignedUrl);

        return preSignedUrl;
    }
};