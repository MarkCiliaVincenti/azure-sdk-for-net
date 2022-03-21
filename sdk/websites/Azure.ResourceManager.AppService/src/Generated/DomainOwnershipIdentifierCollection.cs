// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of DomainOwnershipIdentifier and their operations over its parent. </summary>
    public partial class DomainOwnershipIdentifierCollection : ArmCollection, IEnumerable<DomainOwnershipIdentifier>, IAsyncEnumerable<DomainOwnershipIdentifier>
    {
        private readonly ClientDiagnostics _domainOwnershipIdentifierDomainsClientDiagnostics;
        private readonly DomainsRestOperations _domainOwnershipIdentifierDomainsRestClient;

        /// <summary> Initializes a new instance of the <see cref="DomainOwnershipIdentifierCollection"/> class for mocking. </summary>
        protected DomainOwnershipIdentifierCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DomainOwnershipIdentifierCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DomainOwnershipIdentifierCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _domainOwnershipIdentifierDomainsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", DomainOwnershipIdentifier.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(DomainOwnershipIdentifier.ResourceType, out string domainOwnershipIdentifierDomainsApiVersion);
            _domainOwnershipIdentifierDomainsRestClient = new DomainsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, domainOwnershipIdentifierDomainsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AppServiceDomain.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AppServiceDomain.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Creates an ownership identifier for a domain or updates identifier details for an existing identifier
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}
        /// Operation Id: Domains_CreateOrUpdateOwnershipIdentifier
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="domainOwnershipIdentifier"> A JSON representation of the domain ownership properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="domainOwnershipIdentifier"/> is null. </exception>
        public virtual async Task<ArmOperation<DomainOwnershipIdentifier>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, DomainOwnershipIdentifierData domainOwnershipIdentifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(domainOwnershipIdentifier, nameof(domainOwnershipIdentifier));

            using var scope = _domainOwnershipIdentifierDomainsClientDiagnostics.CreateScope("DomainOwnershipIdentifierCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _domainOwnershipIdentifierDomainsRestClient.CreateOrUpdateOwnershipIdentifierAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, domainOwnershipIdentifier, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation<DomainOwnershipIdentifier>(Response.FromValue(new DomainOwnershipIdentifier(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Creates an ownership identifier for a domain or updates identifier details for an existing identifier
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}
        /// Operation Id: Domains_CreateOrUpdateOwnershipIdentifier
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="domainOwnershipIdentifier"> A JSON representation of the domain ownership properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="domainOwnershipIdentifier"/> is null. </exception>
        public virtual ArmOperation<DomainOwnershipIdentifier> CreateOrUpdate(WaitUntil waitUntil, string name, DomainOwnershipIdentifierData domainOwnershipIdentifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(domainOwnershipIdentifier, nameof(domainOwnershipIdentifier));

            using var scope = _domainOwnershipIdentifierDomainsClientDiagnostics.CreateScope("DomainOwnershipIdentifierCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _domainOwnershipIdentifierDomainsRestClient.CreateOrUpdateOwnershipIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, domainOwnershipIdentifier, cancellationToken);
                var operation = new AppServiceArmOperation<DomainOwnershipIdentifier>(Response.FromValue(new DomainOwnershipIdentifier(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get ownership identifier for domain
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}
        /// Operation Id: Domains_GetOwnershipIdentifier
        /// </summary>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<DomainOwnershipIdentifier>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _domainOwnershipIdentifierDomainsClientDiagnostics.CreateScope("DomainOwnershipIdentifierCollection.Get");
            scope.Start();
            try
            {
                var response = await _domainOwnershipIdentifierDomainsRestClient.GetOwnershipIdentifierAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DomainOwnershipIdentifier(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get ownership identifier for domain
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}
        /// Operation Id: Domains_GetOwnershipIdentifier
        /// </summary>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<DomainOwnershipIdentifier> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _domainOwnershipIdentifierDomainsClientDiagnostics.CreateScope("DomainOwnershipIdentifierCollection.Get");
            scope.Start();
            try
            {
                var response = _domainOwnershipIdentifierDomainsRestClient.GetOwnershipIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DomainOwnershipIdentifier(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Lists domain ownership identifiers.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers
        /// Operation Id: Domains_ListOwnershipIdentifiers
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DomainOwnershipIdentifier" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DomainOwnershipIdentifier> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DomainOwnershipIdentifier>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _domainOwnershipIdentifierDomainsClientDiagnostics.CreateScope("DomainOwnershipIdentifierCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _domainOwnershipIdentifierDomainsRestClient.ListOwnershipIdentifiersAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DomainOwnershipIdentifier(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DomainOwnershipIdentifier>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _domainOwnershipIdentifierDomainsClientDiagnostics.CreateScope("DomainOwnershipIdentifierCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _domainOwnershipIdentifierDomainsRestClient.ListOwnershipIdentifiersNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DomainOwnershipIdentifier(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Description for Lists domain ownership identifiers.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers
        /// Operation Id: Domains_ListOwnershipIdentifiers
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DomainOwnershipIdentifier" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DomainOwnershipIdentifier> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DomainOwnershipIdentifier> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _domainOwnershipIdentifierDomainsClientDiagnostics.CreateScope("DomainOwnershipIdentifierCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _domainOwnershipIdentifierDomainsRestClient.ListOwnershipIdentifiers(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DomainOwnershipIdentifier(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DomainOwnershipIdentifier> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _domainOwnershipIdentifierDomainsClientDiagnostics.CreateScope("DomainOwnershipIdentifierCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _domainOwnershipIdentifierDomainsRestClient.ListOwnershipIdentifiersNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DomainOwnershipIdentifier(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}
        /// Operation Id: Domains_GetOwnershipIdentifier
        /// </summary>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _domainOwnershipIdentifierDomainsClientDiagnostics.CreateScope("DomainOwnershipIdentifierCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}
        /// Operation Id: Domains_GetOwnershipIdentifier
        /// </summary>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _domainOwnershipIdentifierDomainsClientDiagnostics.CreateScope("DomainOwnershipIdentifierCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(name, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}
        /// Operation Id: Domains_GetOwnershipIdentifier
        /// </summary>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<DomainOwnershipIdentifier>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _domainOwnershipIdentifierDomainsClientDiagnostics.CreateScope("DomainOwnershipIdentifierCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _domainOwnershipIdentifierDomainsRestClient.GetOwnershipIdentifierAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DomainOwnershipIdentifier>(null, response.GetRawResponse());
                return Response.FromValue(new DomainOwnershipIdentifier(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}
        /// Operation Id: Domains_GetOwnershipIdentifier
        /// </summary>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<DomainOwnershipIdentifier> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _domainOwnershipIdentifierDomainsClientDiagnostics.CreateScope("DomainOwnershipIdentifierCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _domainOwnershipIdentifierDomainsRestClient.GetOwnershipIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DomainOwnershipIdentifier>(null, response.GetRawResponse());
                return Response.FromValue(new DomainOwnershipIdentifier(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DomainOwnershipIdentifier> IEnumerable<DomainOwnershipIdentifier>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DomainOwnershipIdentifier> IAsyncEnumerable<DomainOwnershipIdentifier>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
