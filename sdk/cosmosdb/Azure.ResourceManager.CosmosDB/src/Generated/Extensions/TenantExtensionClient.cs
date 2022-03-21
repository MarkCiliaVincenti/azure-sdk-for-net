// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.CosmosDB
{
    /// <summary> A class to add extension methods to Tenant. </summary>
    internal partial class TenantExtensionClient : ArmResource
    {
        private ClientDiagnostics _databaseAccountClientDiagnostics;
        private DatabaseAccountsRestOperations _databaseAccountRestClient;

        /// <summary> Initializes a new instance of the <see cref="TenantExtensionClient"/> class for mocking. </summary>
        protected TenantExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TenantExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal TenantExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics DatabaseAccountClientDiagnostics => _databaseAccountClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.CosmosDB", DatabaseAccount.ResourceType.Namespace, DiagnosticOptions);
        private DatabaseAccountsRestOperations DatabaseAccountRestClient => _databaseAccountRestClient ??= new DatabaseAccountsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(DatabaseAccount.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Checks that the Azure Cosmos DB account name already exists. A valid account name may contain only lowercase letters, numbers, and the &apos;-&apos; character, and must be between 3 and 50 characters.
        /// Request Path: /providers/Microsoft.DocumentDB/databaseAccountNames/{accountName}
        /// Operation Id: DatabaseAccounts_CheckNameExists
        /// </summary>
        /// <param name="accountName"> Cosmos DB database account name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> CheckNameExistsDatabaseAccountAsync(string accountName, CancellationToken cancellationToken = default)
        {
            using var scope = DatabaseAccountClientDiagnostics.CreateScope("TenantExtensionClient.CheckNameExistsDatabaseAccount");
            scope.Start();
            try
            {
                var response = await DatabaseAccountRestClient.CheckNameExistsAsync(accountName, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks that the Azure Cosmos DB account name already exists. A valid account name may contain only lowercase letters, numbers, and the &apos;-&apos; character, and must be between 3 and 50 characters.
        /// Request Path: /providers/Microsoft.DocumentDB/databaseAccountNames/{accountName}
        /// Operation Id: DatabaseAccounts_CheckNameExists
        /// </summary>
        /// <param name="accountName"> Cosmos DB database account name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> CheckNameExistsDatabaseAccount(string accountName, CancellationToken cancellationToken = default)
        {
            using var scope = DatabaseAccountClientDiagnostics.CreateScope("TenantExtensionClient.CheckNameExistsDatabaseAccount");
            scope.Start();
            try
            {
                var response = DatabaseAccountRestClient.CheckNameExists(accountName, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
