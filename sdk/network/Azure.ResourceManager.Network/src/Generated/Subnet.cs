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
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A Class representing a Subnet along with the instance operations that can be performed on it. </summary>
    public partial class Subnet : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="Subnet"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName, string subnetName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _subnetClientDiagnostics;
        private readonly SubnetsRestOperations _subnetRestClient;
        private readonly ClientDiagnostics _resourceNavigationLinksClientDiagnostics;
        private readonly ResourceNavigationLinksRestOperations _resourceNavigationLinksRestClient;
        private readonly ClientDiagnostics _serviceAssociationLinksClientDiagnostics;
        private readonly ServiceAssociationLinksRestOperations _serviceAssociationLinksRestClient;
        private readonly SubnetData _data;

        /// <summary> Initializes a new instance of the <see cref="Subnet"/> class for mocking. </summary>
        protected Subnet()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Subnet"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal Subnet(ArmClient client, SubnetData data) : this(client, new ResourceIdentifier(data.Id))
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="Subnet"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Subnet(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _subnetClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string subnetApiVersion);
            _subnetRestClient = new SubnetsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, subnetApiVersion);
            _resourceNavigationLinksClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
            _resourceNavigationLinksRestClient = new ResourceNavigationLinksRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
            _serviceAssociationLinksClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
            _serviceAssociationLinksRestClient = new ServiceAssociationLinksRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/virtualNetworks/subnets";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SubnetData Data
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
        /// Gets the specified subnet by virtual network and resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}
        /// Operation Id: Subnets_Get
        /// </summary>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Subnet>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _subnetClientDiagnostics.CreateScope("Subnet.Get");
            scope.Start();
            try
            {
                var response = await _subnetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Subnet(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified subnet by virtual network and resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}
        /// Operation Id: Subnets_Get
        /// </summary>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Subnet> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _subnetClientDiagnostics.CreateScope("Subnet.Get");
            scope.Start();
            try
            {
                var response = _subnetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Subnet(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified subnet.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}
        /// Operation Id: Subnets_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _subnetClientDiagnostics.CreateScope("Subnet.Delete");
            scope.Start();
            try
            {
                var response = await _subnetRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation(_subnetClientDiagnostics, Pipeline, _subnetRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Deletes the specified subnet.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}
        /// Operation Id: Subnets_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _subnetClientDiagnostics.CreateScope("Subnet.Delete");
            scope.Start();
            try
            {
                var response = _subnetRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new NetworkArmOperation(_subnetClientDiagnostics, Pipeline, _subnetRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Prepares a subnet by applying network intent policies.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}/PrepareNetworkPolicies
        /// Operation Id: Subnets_PrepareNetworkPolicies
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="prepareNetworkPoliciesRequestParameters"> Parameters supplied to prepare subnet by applying network intent policies. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="prepareNetworkPoliciesRequestParameters"/> is null. </exception>
        public virtual async Task<ArmOperation> PrepareNetworkPoliciesAsync(WaitUntil waitUntil, PrepareNetworkPoliciesRequest prepareNetworkPoliciesRequestParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(prepareNetworkPoliciesRequestParameters, nameof(prepareNetworkPoliciesRequestParameters));

            using var scope = _subnetClientDiagnostics.CreateScope("Subnet.PrepareNetworkPolicies");
            scope.Start();
            try
            {
                var response = await _subnetRestClient.PrepareNetworkPoliciesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, prepareNetworkPoliciesRequestParameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation(_subnetClientDiagnostics, Pipeline, _subnetRestClient.CreatePrepareNetworkPoliciesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, prepareNetworkPoliciesRequestParameters).Request, response, OperationFinalStateVia.Location);
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
        /// Prepares a subnet by applying network intent policies.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}/PrepareNetworkPolicies
        /// Operation Id: Subnets_PrepareNetworkPolicies
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="prepareNetworkPoliciesRequestParameters"> Parameters supplied to prepare subnet by applying network intent policies. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="prepareNetworkPoliciesRequestParameters"/> is null. </exception>
        public virtual ArmOperation PrepareNetworkPolicies(WaitUntil waitUntil, PrepareNetworkPoliciesRequest prepareNetworkPoliciesRequestParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(prepareNetworkPoliciesRequestParameters, nameof(prepareNetworkPoliciesRequestParameters));

            using var scope = _subnetClientDiagnostics.CreateScope("Subnet.PrepareNetworkPolicies");
            scope.Start();
            try
            {
                var response = _subnetRestClient.PrepareNetworkPolicies(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, prepareNetworkPoliciesRequestParameters, cancellationToken);
                var operation = new NetworkArmOperation(_subnetClientDiagnostics, Pipeline, _subnetRestClient.CreatePrepareNetworkPoliciesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, prepareNetworkPoliciesRequestParameters).Request, response, OperationFinalStateVia.Location);
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
        /// Unprepares a subnet by removing network intent policies.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}/UnprepareNetworkPolicies
        /// Operation Id: Subnets_UnprepareNetworkPolicies
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="unprepareNetworkPoliciesRequestParameters"> Parameters supplied to unprepare subnet to remove network intent policies. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="unprepareNetworkPoliciesRequestParameters"/> is null. </exception>
        public virtual async Task<ArmOperation> UnprepareNetworkPoliciesAsync(WaitUntil waitUntil, UnprepareNetworkPoliciesRequest unprepareNetworkPoliciesRequestParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(unprepareNetworkPoliciesRequestParameters, nameof(unprepareNetworkPoliciesRequestParameters));

            using var scope = _subnetClientDiagnostics.CreateScope("Subnet.UnprepareNetworkPolicies");
            scope.Start();
            try
            {
                var response = await _subnetRestClient.UnprepareNetworkPoliciesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, unprepareNetworkPoliciesRequestParameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation(_subnetClientDiagnostics, Pipeline, _subnetRestClient.CreateUnprepareNetworkPoliciesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, unprepareNetworkPoliciesRequestParameters).Request, response, OperationFinalStateVia.Location);
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
        /// Unprepares a subnet by removing network intent policies.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}/UnprepareNetworkPolicies
        /// Operation Id: Subnets_UnprepareNetworkPolicies
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="unprepareNetworkPoliciesRequestParameters"> Parameters supplied to unprepare subnet to remove network intent policies. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="unprepareNetworkPoliciesRequestParameters"/> is null. </exception>
        public virtual ArmOperation UnprepareNetworkPolicies(WaitUntil waitUntil, UnprepareNetworkPoliciesRequest unprepareNetworkPoliciesRequestParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(unprepareNetworkPoliciesRequestParameters, nameof(unprepareNetworkPoliciesRequestParameters));

            using var scope = _subnetClientDiagnostics.CreateScope("Subnet.UnprepareNetworkPolicies");
            scope.Start();
            try
            {
                var response = _subnetRestClient.UnprepareNetworkPolicies(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, unprepareNetworkPoliciesRequestParameters, cancellationToken);
                var operation = new NetworkArmOperation(_subnetClientDiagnostics, Pipeline, _subnetRestClient.CreateUnprepareNetworkPoliciesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, unprepareNetworkPoliciesRequestParameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a list of resource navigation links for a subnet.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}/ResourceNavigationLinks
        /// Operation Id: ResourceNavigationLinks_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceNavigationLink" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceNavigationLink> GetResourceNavigationLinksAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResourceNavigationLink>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceNavigationLinksClientDiagnostics.CreateScope("Subnet.GetResourceNavigationLinks");
                scope.Start();
                try
                {
                    var response = await _resourceNavigationLinksRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets a list of resource navigation links for a subnet.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}/ResourceNavigationLinks
        /// Operation Id: ResourceNavigationLinks_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceNavigationLink" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceNavigationLink> GetResourceNavigationLinks(CancellationToken cancellationToken = default)
        {
            Page<ResourceNavigationLink> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceNavigationLinksClientDiagnostics.CreateScope("Subnet.GetResourceNavigationLinks");
                scope.Start();
                try
                {
                    var response = _resourceNavigationLinksRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets a list of service association links for a subnet.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}/ServiceAssociationLinks
        /// Operation Id: ServiceAssociationLinks_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServiceAssociationLink" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServiceAssociationLink> GetServiceAssociationLinksAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ServiceAssociationLink>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serviceAssociationLinksClientDiagnostics.CreateScope("Subnet.GetServiceAssociationLinks");
                scope.Start();
                try
                {
                    var response = await _serviceAssociationLinksRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets a list of service association links for a subnet.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}/ServiceAssociationLinks
        /// Operation Id: ServiceAssociationLinks_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServiceAssociationLink" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServiceAssociationLink> GetServiceAssociationLinks(CancellationToken cancellationToken = default)
        {
            Page<ServiceAssociationLink> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serviceAssociationLinksClientDiagnostics.CreateScope("Subnet.GetServiceAssociationLinks");
                scope.Start();
                try
                {
                    var response = _serviceAssociationLinksRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }
    }
}
