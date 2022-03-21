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

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of ManagedInstanceDatabaseSchemaTableColumn and their operations over its parent. </summary>
    public partial class ManagedInstanceDatabaseSchemaTableColumnCollection : ArmCollection, IEnumerable<ManagedInstanceDatabaseSchemaTableColumn>, IAsyncEnumerable<ManagedInstanceDatabaseSchemaTableColumn>
    {
        private readonly ClientDiagnostics _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsClientDiagnostics;
        private readonly ManagedDatabaseColumnsRestOperations _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsRestClient;

        /// <summary> Initializes a new instance of the <see cref="ManagedInstanceDatabaseSchemaTableColumnCollection"/> class for mocking. </summary>
        protected ManagedInstanceDatabaseSchemaTableColumnCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagedInstanceDatabaseSchemaTableColumnCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ManagedInstanceDatabaseSchemaTableColumnCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ManagedInstanceDatabaseSchemaTableColumn.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ManagedInstanceDatabaseSchemaTableColumn.ResourceType, out string managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsApiVersion);
            _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsRestClient = new ManagedDatabaseColumnsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ManagedInstanceDatabaseSchemaTable.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ManagedInstanceDatabaseSchemaTable.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get managed database column
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}
        /// Operation Id: ManagedDatabaseColumns_Get
        /// </summary>
        /// <param name="columnName"> The name of the column. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="columnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="columnName"/> is null. </exception>
        public virtual async Task<Response<ManagedInstanceDatabaseSchemaTableColumn>> GetAsync(string columnName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(columnName, nameof(columnName));

            using var scope = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaTableColumnCollection.Get");
            scope.Start();
            try
            {
                var response = await _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, columnName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceDatabaseSchemaTableColumn(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get managed database column
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}
        /// Operation Id: ManagedDatabaseColumns_Get
        /// </summary>
        /// <param name="columnName"> The name of the column. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="columnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="columnName"/> is null. </exception>
        public virtual Response<ManagedInstanceDatabaseSchemaTableColumn> Get(string columnName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(columnName, nameof(columnName));

            using var scope = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaTableColumnCollection.Get");
            scope.Start();
            try
            {
                var response = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, columnName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceDatabaseSchemaTableColumn(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List managed database columns
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns
        /// Operation Id: ManagedDatabaseColumns_ListByTable
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedInstanceDatabaseSchemaTableColumn" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedInstanceDatabaseSchemaTableColumn> GetAllAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedInstanceDatabaseSchemaTableColumn>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaTableColumnCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsRestClient.ListByTableAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceDatabaseSchemaTableColumn(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagedInstanceDatabaseSchemaTableColumn>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaTableColumnCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsRestClient.ListByTableNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceDatabaseSchemaTableColumn(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List managed database columns
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns
        /// Operation Id: ManagedDatabaseColumns_ListByTable
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedInstanceDatabaseSchemaTableColumn" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedInstanceDatabaseSchemaTableColumn> GetAll(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedInstanceDatabaseSchemaTableColumn> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaTableColumnCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsRestClient.ListByTable(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceDatabaseSchemaTableColumn(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagedInstanceDatabaseSchemaTableColumn> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaTableColumnCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsRestClient.ListByTableNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceDatabaseSchemaTableColumn(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}
        /// Operation Id: ManagedDatabaseColumns_Get
        /// </summary>
        /// <param name="columnName"> The name of the column. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="columnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="columnName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string columnName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(columnName, nameof(columnName));

            using var scope = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaTableColumnCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(columnName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}
        /// Operation Id: ManagedDatabaseColumns_Get
        /// </summary>
        /// <param name="columnName"> The name of the column. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="columnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="columnName"/> is null. </exception>
        public virtual Response<bool> Exists(string columnName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(columnName, nameof(columnName));

            using var scope = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaTableColumnCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(columnName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}
        /// Operation Id: ManagedDatabaseColumns_Get
        /// </summary>
        /// <param name="columnName"> The name of the column. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="columnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="columnName"/> is null. </exception>
        public virtual async Task<Response<ManagedInstanceDatabaseSchemaTableColumn>> GetIfExistsAsync(string columnName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(columnName, nameof(columnName));

            using var scope = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaTableColumnCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, columnName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ManagedInstanceDatabaseSchemaTableColumn>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceDatabaseSchemaTableColumn(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}
        /// Operation Id: ManagedDatabaseColumns_Get
        /// </summary>
        /// <param name="columnName"> The name of the column. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="columnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="columnName"/> is null. </exception>
        public virtual Response<ManagedInstanceDatabaseSchemaTableColumn> GetIfExists(string columnName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(columnName, nameof(columnName));

            using var scope = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaTableColumnCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _managedInstanceDatabaseSchemaTableColumnManagedDatabaseColumnsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, columnName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ManagedInstanceDatabaseSchemaTableColumn>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceDatabaseSchemaTableColumn(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ManagedInstanceDatabaseSchemaTableColumn> IEnumerable<ManagedInstanceDatabaseSchemaTableColumn>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ManagedInstanceDatabaseSchemaTableColumn> IAsyncEnumerable<ManagedInstanceDatabaseSchemaTableColumn>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
