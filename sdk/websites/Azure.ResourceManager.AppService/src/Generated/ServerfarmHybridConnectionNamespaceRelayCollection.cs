// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of ServerfarmHybridConnectionNamespaceRelay and their operations over its parent. </summary>
    public partial class ServerfarmHybridConnectionNamespaceRelayCollection : ArmCollection
    {
        private readonly ClientDiagnostics _serverfarmHybridConnectionNamespaceRelayAppServicePlansClientDiagnostics;
        private readonly AppServicePlansRestOperations _serverfarmHybridConnectionNamespaceRelayAppServicePlansRestClient;

        /// <summary> Initializes a new instance of the <see cref="ServerfarmHybridConnectionNamespaceRelayCollection"/> class for mocking. </summary>
        protected ServerfarmHybridConnectionNamespaceRelayCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ServerfarmHybridConnectionNamespaceRelayCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ServerfarmHybridConnectionNamespaceRelayCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _serverfarmHybridConnectionNamespaceRelayAppServicePlansClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", ServerfarmHybridConnectionNamespaceRelay.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ServerfarmHybridConnectionNamespaceRelay.ResourceType, out string serverfarmHybridConnectionNamespaceRelayAppServicePlansApiVersion);
            _serverfarmHybridConnectionNamespaceRelayAppServicePlansRestClient = new AppServicePlansRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, serverfarmHybridConnectionNamespaceRelayAppServicePlansApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AppServicePlan.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AppServicePlan.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Retrieve a Hybrid Connection in use in an App Service plan.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
        /// Operation Id: AppServicePlans_GetHybridConnection
        /// </summary>
        /// <param name="namespaceName"> Name of the Service Bus namespace. </param>
        /// <param name="relayName"> Name of the Service Bus relay. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> or <paramref name="relayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="relayName"/> is null. </exception>
        public virtual async Task<Response<ServerfarmHybridConnectionNamespaceRelay>> GetAsync(string namespaceName, string relayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
            Argument.AssertNotNullOrEmpty(relayName, nameof(relayName));

            using var scope = _serverfarmHybridConnectionNamespaceRelayAppServicePlansClientDiagnostics.CreateScope("ServerfarmHybridConnectionNamespaceRelayCollection.Get");
            scope.Start();
            try
            {
                var response = await _serverfarmHybridConnectionNamespaceRelayAppServicePlansRestClient.GetHybridConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, namespaceName, relayName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerfarmHybridConnectionNamespaceRelay(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Retrieve a Hybrid Connection in use in an App Service plan.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
        /// Operation Id: AppServicePlans_GetHybridConnection
        /// </summary>
        /// <param name="namespaceName"> Name of the Service Bus namespace. </param>
        /// <param name="relayName"> Name of the Service Bus relay. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> or <paramref name="relayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="relayName"/> is null. </exception>
        public virtual Response<ServerfarmHybridConnectionNamespaceRelay> Get(string namespaceName, string relayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
            Argument.AssertNotNullOrEmpty(relayName, nameof(relayName));

            using var scope = _serverfarmHybridConnectionNamespaceRelayAppServicePlansClientDiagnostics.CreateScope("ServerfarmHybridConnectionNamespaceRelayCollection.Get");
            scope.Start();
            try
            {
                var response = _serverfarmHybridConnectionNamespaceRelayAppServicePlansRestClient.GetHybridConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, namespaceName, relayName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerfarmHybridConnectionNamespaceRelay(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
        /// Operation Id: AppServicePlans_GetHybridConnection
        /// </summary>
        /// <param name="namespaceName"> Name of the Service Bus namespace. </param>
        /// <param name="relayName"> Name of the Service Bus relay. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> or <paramref name="relayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="relayName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string namespaceName, string relayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
            Argument.AssertNotNullOrEmpty(relayName, nameof(relayName));

            using var scope = _serverfarmHybridConnectionNamespaceRelayAppServicePlansClientDiagnostics.CreateScope("ServerfarmHybridConnectionNamespaceRelayCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(namespaceName, relayName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
        /// Operation Id: AppServicePlans_GetHybridConnection
        /// </summary>
        /// <param name="namespaceName"> Name of the Service Bus namespace. </param>
        /// <param name="relayName"> Name of the Service Bus relay. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> or <paramref name="relayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="relayName"/> is null. </exception>
        public virtual Response<bool> Exists(string namespaceName, string relayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
            Argument.AssertNotNullOrEmpty(relayName, nameof(relayName));

            using var scope = _serverfarmHybridConnectionNamespaceRelayAppServicePlansClientDiagnostics.CreateScope("ServerfarmHybridConnectionNamespaceRelayCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(namespaceName, relayName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
        /// Operation Id: AppServicePlans_GetHybridConnection
        /// </summary>
        /// <param name="namespaceName"> Name of the Service Bus namespace. </param>
        /// <param name="relayName"> Name of the Service Bus relay. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> or <paramref name="relayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="relayName"/> is null. </exception>
        public virtual async Task<Response<ServerfarmHybridConnectionNamespaceRelay>> GetIfExistsAsync(string namespaceName, string relayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
            Argument.AssertNotNullOrEmpty(relayName, nameof(relayName));

            using var scope = _serverfarmHybridConnectionNamespaceRelayAppServicePlansClientDiagnostics.CreateScope("ServerfarmHybridConnectionNamespaceRelayCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _serverfarmHybridConnectionNamespaceRelayAppServicePlansRestClient.GetHybridConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, namespaceName, relayName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ServerfarmHybridConnectionNamespaceRelay>(null, response.GetRawResponse());
                return Response.FromValue(new ServerfarmHybridConnectionNamespaceRelay(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
        /// Operation Id: AppServicePlans_GetHybridConnection
        /// </summary>
        /// <param name="namespaceName"> Name of the Service Bus namespace. </param>
        /// <param name="relayName"> Name of the Service Bus relay. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> or <paramref name="relayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="relayName"/> is null. </exception>
        public virtual Response<ServerfarmHybridConnectionNamespaceRelay> GetIfExists(string namespaceName, string relayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
            Argument.AssertNotNullOrEmpty(relayName, nameof(relayName));

            using var scope = _serverfarmHybridConnectionNamespaceRelayAppServicePlansClientDiagnostics.CreateScope("ServerfarmHybridConnectionNamespaceRelayCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _serverfarmHybridConnectionNamespaceRelayAppServicePlansRestClient.GetHybridConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, namespaceName, relayName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ServerfarmHybridConnectionNamespaceRelay>(null, response.GetRawResponse());
                return Response.FromValue(new ServerfarmHybridConnectionNamespaceRelay(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
