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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of TopLevelDomain and their operations over its parent. </summary>
    public partial class TopLevelDomainCollection : ArmCollection, IEnumerable<TopLevelDomain>, IAsyncEnumerable<TopLevelDomain>
    {
        private readonly ClientDiagnostics _topLevelDomainClientDiagnostics;
        private readonly TopLevelDomainsRestOperations _topLevelDomainRestClient;

        /// <summary> Initializes a new instance of the <see cref="TopLevelDomainCollection"/> class for mocking. </summary>
        protected TopLevelDomainCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TopLevelDomainCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TopLevelDomainCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _topLevelDomainClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", TopLevelDomain.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(TopLevelDomain.ResourceType, out string topLevelDomainApiVersion);
            _topLevelDomainRestClient = new TopLevelDomainsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, topLevelDomainApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Get details of a top-level domain.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/topLevelDomains/{name}
        /// Operation Id: TopLevelDomains_Get
        /// </summary>
        /// <param name="name"> Name of the top-level domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<TopLevelDomain>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _topLevelDomainClientDiagnostics.CreateScope("TopLevelDomainCollection.Get");
            scope.Start();
            try
            {
                var response = await _topLevelDomainRestClient.GetAsync(Id.SubscriptionId, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TopLevelDomain(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get details of a top-level domain.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/topLevelDomains/{name}
        /// Operation Id: TopLevelDomains_Get
        /// </summary>
        /// <param name="name"> Name of the top-level domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<TopLevelDomain> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _topLevelDomainClientDiagnostics.CreateScope("TopLevelDomainCollection.Get");
            scope.Start();
            try
            {
                var response = _topLevelDomainRestClient.Get(Id.SubscriptionId, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TopLevelDomain(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get all top-level domains supported for registration.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/topLevelDomains
        /// Operation Id: TopLevelDomains_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TopLevelDomain" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TopLevelDomain> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TopLevelDomain>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _topLevelDomainClientDiagnostics.CreateScope("TopLevelDomainCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _topLevelDomainRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TopLevelDomain(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TopLevelDomain>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _topLevelDomainClientDiagnostics.CreateScope("TopLevelDomainCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _topLevelDomainRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TopLevelDomain(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Description for Get all top-level domains supported for registration.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/topLevelDomains
        /// Operation Id: TopLevelDomains_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TopLevelDomain" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TopLevelDomain> GetAll(CancellationToken cancellationToken = default)
        {
            Page<TopLevelDomain> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _topLevelDomainClientDiagnostics.CreateScope("TopLevelDomainCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _topLevelDomainRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TopLevelDomain(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TopLevelDomain> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _topLevelDomainClientDiagnostics.CreateScope("TopLevelDomainCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _topLevelDomainRestClient.ListNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TopLevelDomain(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/topLevelDomains/{name}
        /// Operation Id: TopLevelDomains_Get
        /// </summary>
        /// <param name="name"> Name of the top-level domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _topLevelDomainClientDiagnostics.CreateScope("TopLevelDomainCollection.Exists");
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/topLevelDomains/{name}
        /// Operation Id: TopLevelDomains_Get
        /// </summary>
        /// <param name="name"> Name of the top-level domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _topLevelDomainClientDiagnostics.CreateScope("TopLevelDomainCollection.Exists");
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/topLevelDomains/{name}
        /// Operation Id: TopLevelDomains_Get
        /// </summary>
        /// <param name="name"> Name of the top-level domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<TopLevelDomain>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _topLevelDomainClientDiagnostics.CreateScope("TopLevelDomainCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _topLevelDomainRestClient.GetAsync(Id.SubscriptionId, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TopLevelDomain>(null, response.GetRawResponse());
                return Response.FromValue(new TopLevelDomain(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DomainRegistration/topLevelDomains/{name}
        /// Operation Id: TopLevelDomains_Get
        /// </summary>
        /// <param name="name"> Name of the top-level domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<TopLevelDomain> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _topLevelDomainClientDiagnostics.CreateScope("TopLevelDomainCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _topLevelDomainRestClient.Get(Id.SubscriptionId, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TopLevelDomain>(null, response.GetRawResponse());
                return Response.FromValue(new TopLevelDomain(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TopLevelDomain> IEnumerable<TopLevelDomain>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TopLevelDomain> IAsyncEnumerable<TopLevelDomain>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
