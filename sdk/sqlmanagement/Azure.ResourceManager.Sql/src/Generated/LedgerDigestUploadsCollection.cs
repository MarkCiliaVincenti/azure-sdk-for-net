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
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of LedgerDigestUploads and their operations over its parent. </summary>
    public partial class LedgerDigestUploadsCollection : ArmCollection, IEnumerable<LedgerDigestUploads>, IAsyncEnumerable<LedgerDigestUploads>
    {
        private readonly ClientDiagnostics _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics;
        private readonly LedgerDigestUploadsRestOperations _ledgerDigestUploadsLedgerDigestUploadsRestClient;

        /// <summary> Initializes a new instance of the <see cref="LedgerDigestUploadsCollection"/> class for mocking. </summary>
        protected LedgerDigestUploadsCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="LedgerDigestUploadsCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal LedgerDigestUploadsCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", LedgerDigestUploads.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(LedgerDigestUploads.ResourceType, out string ledgerDigestUploadsLedgerDigestUploadsApiVersion);
            _ledgerDigestUploadsLedgerDigestUploadsRestClient = new LedgerDigestUploadsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, ledgerDigestUploadsLedgerDigestUploadsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlDatabase.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlDatabase.ResourceType), nameof(id));
        }

        /// <summary>
        /// Enables upload ledger digests to an Azure Storage account or an Azure Confidential Ledger instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}
        /// Operation Id: LedgerDigestUploads_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ledgerDigestUploads"> The LedgerDigestUploadsName to use. </param>
        /// <param name="parameters"> The LedgerDigestUploads to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<LedgerDigestUploads>> CreateOrUpdateAsync(WaitUntil waitUntil, LedgerDigestUploadsName ledgerDigestUploads, LedgerDigestUploadsData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploadsCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _ledgerDigestUploadsLedgerDigestUploadsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ledgerDigestUploads, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<LedgerDigestUploads>(new LedgerDigestUploadsOperationSource(Client), _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics, Pipeline, _ledgerDigestUploadsLedgerDigestUploadsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ledgerDigestUploads, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Enables upload ledger digests to an Azure Storage account or an Azure Confidential Ledger instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}
        /// Operation Id: LedgerDigestUploads_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ledgerDigestUploads"> The LedgerDigestUploadsName to use. </param>
        /// <param name="parameters"> The LedgerDigestUploads to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<LedgerDigestUploads> CreateOrUpdate(WaitUntil waitUntil, LedgerDigestUploadsName ledgerDigestUploads, LedgerDigestUploadsData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploadsCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _ledgerDigestUploadsLedgerDigestUploadsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ledgerDigestUploads, parameters, cancellationToken);
                var operation = new SqlArmOperation<LedgerDigestUploads>(new LedgerDigestUploadsOperationSource(Client), _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics, Pipeline, _ledgerDigestUploadsLedgerDigestUploadsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ledgerDigestUploads, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the current ledger digest upload configuration for a database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}
        /// Operation Id: LedgerDigestUploads_Get
        /// </summary>
        /// <param name="ledgerDigestUploads"> The LedgerDigestUploadsName to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<LedgerDigestUploads>> GetAsync(LedgerDigestUploadsName ledgerDigestUploads, CancellationToken cancellationToken = default)
        {
            using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploadsCollection.Get");
            scope.Start();
            try
            {
                var response = await _ledgerDigestUploadsLedgerDigestUploadsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ledgerDigestUploads, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new LedgerDigestUploads(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the current ledger digest upload configuration for a database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}
        /// Operation Id: LedgerDigestUploads_Get
        /// </summary>
        /// <param name="ledgerDigestUploads"> The LedgerDigestUploadsName to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<LedgerDigestUploads> Get(LedgerDigestUploadsName ledgerDigestUploads, CancellationToken cancellationToken = default)
        {
            using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploadsCollection.Get");
            scope.Start();
            try
            {
                var response = _ledgerDigestUploadsLedgerDigestUploadsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ledgerDigestUploads, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new LedgerDigestUploads(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all ledger digest upload settings on a database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads
        /// Operation Id: LedgerDigestUploads_ListByDatabase
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="LedgerDigestUploads" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<LedgerDigestUploads> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<LedgerDigestUploads>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploadsCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _ledgerDigestUploadsLedgerDigestUploadsRestClient.ListByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new LedgerDigestUploads(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<LedgerDigestUploads>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploadsCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _ledgerDigestUploadsLedgerDigestUploadsRestClient.ListByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new LedgerDigestUploads(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all ledger digest upload settings on a database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads
        /// Operation Id: LedgerDigestUploads_ListByDatabase
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="LedgerDigestUploads" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<LedgerDigestUploads> GetAll(CancellationToken cancellationToken = default)
        {
            Page<LedgerDigestUploads> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploadsCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _ledgerDigestUploadsLedgerDigestUploadsRestClient.ListByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new LedgerDigestUploads(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<LedgerDigestUploads> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploadsCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _ledgerDigestUploadsLedgerDigestUploadsRestClient.ListByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new LedgerDigestUploads(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}
        /// Operation Id: LedgerDigestUploads_Get
        /// </summary>
        /// <param name="ledgerDigestUploads"> The LedgerDigestUploadsName to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(LedgerDigestUploadsName ledgerDigestUploads, CancellationToken cancellationToken = default)
        {
            using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploadsCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(ledgerDigestUploads, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}
        /// Operation Id: LedgerDigestUploads_Get
        /// </summary>
        /// <param name="ledgerDigestUploads"> The LedgerDigestUploadsName to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(LedgerDigestUploadsName ledgerDigestUploads, CancellationToken cancellationToken = default)
        {
            using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploadsCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(ledgerDigestUploads, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}
        /// Operation Id: LedgerDigestUploads_Get
        /// </summary>
        /// <param name="ledgerDigestUploads"> The LedgerDigestUploadsName to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<LedgerDigestUploads>> GetIfExistsAsync(LedgerDigestUploadsName ledgerDigestUploads, CancellationToken cancellationToken = default)
        {
            using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploadsCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _ledgerDigestUploadsLedgerDigestUploadsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ledgerDigestUploads, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<LedgerDigestUploads>(null, response.GetRawResponse());
                return Response.FromValue(new LedgerDigestUploads(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/ledgerDigestUploads/{ledgerDigestUploads}
        /// Operation Id: LedgerDigestUploads_Get
        /// </summary>
        /// <param name="ledgerDigestUploads"> The LedgerDigestUploadsName to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<LedgerDigestUploads> GetIfExists(LedgerDigestUploadsName ledgerDigestUploads, CancellationToken cancellationToken = default)
        {
            using var scope = _ledgerDigestUploadsLedgerDigestUploadsClientDiagnostics.CreateScope("LedgerDigestUploadsCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _ledgerDigestUploadsLedgerDigestUploadsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ledgerDigestUploads, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<LedgerDigestUploads>(null, response.GetRawResponse());
                return Response.FromValue(new LedgerDigestUploads(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<LedgerDigestUploads> IEnumerable<LedgerDigestUploads>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<LedgerDigestUploads> IAsyncEnumerable<LedgerDigestUploads>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
