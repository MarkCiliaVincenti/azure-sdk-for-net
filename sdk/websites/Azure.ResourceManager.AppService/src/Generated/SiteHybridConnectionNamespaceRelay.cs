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
    /// <summary> A Class representing a SiteHybridConnectionNamespaceRelay along with the instance operations that can be performed on it. </summary>
    public partial class SiteHybridConnectionNamespaceRelay : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SiteHybridConnectionNamespaceRelay"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string namespaceName, string relayName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _siteHybridConnectionNamespaceRelayWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteHybridConnectionNamespaceRelayWebAppsRestClient;
        private readonly HybridConnectionData _data;

        /// <summary> Initializes a new instance of the <see cref="SiteHybridConnectionNamespaceRelay"/> class for mocking. </summary>
        protected SiteHybridConnectionNamespaceRelay()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SiteHybridConnectionNamespaceRelay"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SiteHybridConnectionNamespaceRelay(ArmClient client, HybridConnectionData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SiteHybridConnectionNamespaceRelay"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SiteHybridConnectionNamespaceRelay(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteHybridConnectionNamespaceRelayWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string siteHybridConnectionNamespaceRelayWebAppsApiVersion);
            _siteHybridConnectionNamespaceRelayWebAppsRestClient = new WebAppsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteHybridConnectionNamespaceRelayWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Web/sites/hybridConnectionNamespaces/relays";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual HybridConnectionData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Retrieves a specific Service Bus Hybrid Connection used by this Web App.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
        /// Operation Id: WebApps_GetHybridConnection
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SiteHybridConnectionNamespaceRelay>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteHybridConnectionNamespaceRelayWebAppsClientDiagnostics.CreateScope("SiteHybridConnectionNamespaceRelay.Get");
            scope.Start();
            try
            {
                var response = await _siteHybridConnectionNamespaceRelayWebAppsRestClient.GetHybridConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteHybridConnectionNamespaceRelay(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Retrieves a specific Service Bus Hybrid Connection used by this Web App.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
        /// Operation Id: WebApps_GetHybridConnection
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SiteHybridConnectionNamespaceRelay> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _siteHybridConnectionNamespaceRelayWebAppsClientDiagnostics.CreateScope("SiteHybridConnectionNamespaceRelay.Get");
            scope.Start();
            try
            {
                var response = _siteHybridConnectionNamespaceRelayWebAppsRestClient.GetHybridConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteHybridConnectionNamespaceRelay(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Removes a Hybrid Connection from this site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
        /// Operation Id: WebApps_DeleteHybridConnection
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _siteHybridConnectionNamespaceRelayWebAppsClientDiagnostics.CreateScope("SiteHybridConnectionNamespaceRelay.Delete");
            scope.Start();
            try
            {
                var response = await _siteHybridConnectionNamespaceRelayWebAppsRestClient.DeleteHybridConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Removes a Hybrid Connection from this site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
        /// Operation Id: WebApps_DeleteHybridConnection
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _siteHybridConnectionNamespaceRelayWebAppsClientDiagnostics.CreateScope("SiteHybridConnectionNamespaceRelay.Delete");
            scope.Start();
            try
            {
                var response = _siteHybridConnectionNamespaceRelayWebAppsRestClient.DeleteHybridConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new AppServiceArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Creates a new Hybrid Connection using a Service Bus relay.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
        /// Operation Id: WebApps_UpdateHybridConnection
        /// </summary>
        /// <param name="connectionEnvelope"> The details of the hybrid connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionEnvelope"/> is null. </exception>
        public virtual async Task<Response<SiteHybridConnectionNamespaceRelay>> UpdateAsync(HybridConnectionData connectionEnvelope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(connectionEnvelope, nameof(connectionEnvelope));

            using var scope = _siteHybridConnectionNamespaceRelayWebAppsClientDiagnostics.CreateScope("SiteHybridConnectionNamespaceRelay.Update");
            scope.Start();
            try
            {
                var response = await _siteHybridConnectionNamespaceRelayWebAppsRestClient.UpdateHybridConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, connectionEnvelope, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SiteHybridConnectionNamespaceRelay(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Creates a new Hybrid Connection using a Service Bus relay.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
        /// Operation Id: WebApps_UpdateHybridConnection
        /// </summary>
        /// <param name="connectionEnvelope"> The details of the hybrid connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionEnvelope"/> is null. </exception>
        public virtual Response<SiteHybridConnectionNamespaceRelay> Update(HybridConnectionData connectionEnvelope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(connectionEnvelope, nameof(connectionEnvelope));

            using var scope = _siteHybridConnectionNamespaceRelayWebAppsClientDiagnostics.CreateScope("SiteHybridConnectionNamespaceRelay.Update");
            scope.Start();
            try
            {
                var response = _siteHybridConnectionNamespaceRelayWebAppsRestClient.UpdateHybridConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, connectionEnvelope, cancellationToken);
                return Response.FromValue(new SiteHybridConnectionNamespaceRelay(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
