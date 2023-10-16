// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.HybridCompute;
using Azure.ResourceManager.HybridCompute.Models;

namespace Azure.ResourceManager.HybridCompute.Samples
{
    public partial class Sample_HybridComputePrivateEndpointConnectionResource
    {
        // Gets private endpoint connection.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_GetsPrivateEndpointConnection()
        {
            // Generated from example definition: specification/hybridcompute/resource-manager/Microsoft.HybridCompute/stable/2022-12-27/examples/PrivateEndpointConnectionGet.json
            // this example is just showing the usage of "PrivateEndpointConnections_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this HybridComputePrivateEndpointConnectionResource created on azure
            // for more information of creating HybridComputePrivateEndpointConnectionResource, please refer to the document of HybridComputePrivateEndpointConnectionResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "myResourceGroup";
            string scopeName = "myPrivateLinkScope";
            string privateEndpointConnectionName = "private-endpoint-connection-name";
            ResourceIdentifier hybridComputePrivateEndpointConnectionResourceId = HybridComputePrivateEndpointConnectionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName, privateEndpointConnectionName);
            HybridComputePrivateEndpointConnectionResource hybridComputePrivateEndpointConnection = client.GetHybridComputePrivateEndpointConnectionResource(hybridComputePrivateEndpointConnectionResourceId);

            // invoke the operation
            HybridComputePrivateEndpointConnectionResource result = await hybridComputePrivateEndpointConnection.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            HybridComputePrivateEndpointConnectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Approve or reject a private endpoint connection with a given name.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_ApproveOrRejectAPrivateEndpointConnectionWithAGivenName()
        {
            // Generated from example definition: specification/hybridcompute/resource-manager/Microsoft.HybridCompute/stable/2022-12-27/examples/PrivateEndpointConnectionUpdate.json
            // this example is just showing the usage of "PrivateEndpointConnections_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this HybridComputePrivateEndpointConnectionResource created on azure
            // for more information of creating HybridComputePrivateEndpointConnectionResource, please refer to the document of HybridComputePrivateEndpointConnectionResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "myResourceGroup";
            string scopeName = "myPrivateLinkScope";
            string privateEndpointConnectionName = "private-endpoint-connection-name";
            ResourceIdentifier hybridComputePrivateEndpointConnectionResourceId = HybridComputePrivateEndpointConnectionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName, privateEndpointConnectionName);
            HybridComputePrivateEndpointConnectionResource hybridComputePrivateEndpointConnection = client.GetHybridComputePrivateEndpointConnectionResource(hybridComputePrivateEndpointConnectionResourceId);

            // invoke the operation
            HybridComputePrivateEndpointConnectionData data = new HybridComputePrivateEndpointConnectionData()
            {
                Properties = new PrivateEndpointConnectionProperties()
                {
                    ConnectionState = new HybridComputePrivateLinkServiceConnectionStateProperty("Approved", "Approved by johndoe@contoso.com"),
                },
            };
            ArmOperation<HybridComputePrivateEndpointConnectionResource> lro = await hybridComputePrivateEndpointConnection.UpdateAsync(WaitUntil.Completed, data);
            HybridComputePrivateEndpointConnectionResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            HybridComputePrivateEndpointConnectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Deletes a private endpoint connection with a given name.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete_DeletesAPrivateEndpointConnectionWithAGivenName()
        {
            // Generated from example definition: specification/hybridcompute/resource-manager/Microsoft.HybridCompute/stable/2022-12-27/examples/PrivateEndpointConnectionDelete.json
            // this example is just showing the usage of "PrivateEndpointConnections_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this HybridComputePrivateEndpointConnectionResource created on azure
            // for more information of creating HybridComputePrivateEndpointConnectionResource, please refer to the document of HybridComputePrivateEndpointConnectionResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "myResourceGroup";
            string scopeName = "myPrivateLinkScope";
            string privateEndpointConnectionName = "private-endpoint-connection-name";
            ResourceIdentifier hybridComputePrivateEndpointConnectionResourceId = HybridComputePrivateEndpointConnectionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName, privateEndpointConnectionName);
            HybridComputePrivateEndpointConnectionResource hybridComputePrivateEndpointConnection = client.GetHybridComputePrivateEndpointConnectionResource(hybridComputePrivateEndpointConnectionResourceId);

            // invoke the operation
            await hybridComputePrivateEndpointConnection.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }
    }
}
