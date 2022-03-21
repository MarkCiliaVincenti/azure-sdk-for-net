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

namespace Azure.ResourceManager.KeyVault
{
    /// <summary> A Class representing a DeletedVault along with the instance operations that can be performed on it. </summary>
    public partial class DeletedVault : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DeletedVault"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string vaultName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _deletedVaultVaultsClientDiagnostics;
        private readonly VaultsRestOperations _deletedVaultVaultsRestClient;
        private readonly DeletedVaultData _data;

        /// <summary> Initializes a new instance of the <see cref="DeletedVault"/> class for mocking. </summary>
        protected DeletedVault()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "DeletedVault"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DeletedVault(ArmClient client, DeletedVaultData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DeletedVault"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DeletedVault(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deletedVaultVaultsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.KeyVault", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string deletedVaultVaultsApiVersion);
            _deletedVaultVaultsRestClient = new VaultsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, deletedVaultVaultsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.KeyVault/locations/deletedVaults";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DeletedVaultData Data
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
        /// Gets the deleted Azure key vault.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}
        /// Operation Id: Vaults_GetDeleted
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeletedVault>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _deletedVaultVaultsClientDiagnostics.CreateScope("DeletedVault.Get");
            scope.Start();
            try
            {
                var response = await _deletedVaultVaultsRestClient.GetDeletedAsync(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedVault(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the deleted Azure key vault.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}
        /// Operation Id: Vaults_GetDeleted
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeletedVault> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _deletedVaultVaultsClientDiagnostics.CreateScope("DeletedVault.Get");
            scope.Start();
            try
            {
                var response = _deletedVaultVaultsRestClient.GetDeleted(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedVault(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Permanently deletes the specified vault. aka Purges the deleted Azure key vault.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}/purge
        /// Operation Id: Vaults_PurgeDeleted
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> PurgeDeletedAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _deletedVaultVaultsClientDiagnostics.CreateScope("DeletedVault.PurgeDeleted");
            scope.Start();
            try
            {
                var response = await _deletedVaultVaultsRestClient.PurgeDeletedAsync(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new KeyVaultArmOperation(_deletedVaultVaultsClientDiagnostics, Pipeline, _deletedVaultVaultsRestClient.CreatePurgeDeletedRequest(Id.SubscriptionId, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Permanently deletes the specified vault. aka Purges the deleted Azure key vault.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}/purge
        /// Operation Id: Vaults_PurgeDeleted
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation PurgeDeleted(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _deletedVaultVaultsClientDiagnostics.CreateScope("DeletedVault.PurgeDeleted");
            scope.Start();
            try
            {
                var response = _deletedVaultVaultsRestClient.PurgeDeleted(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new KeyVaultArmOperation(_deletedVaultVaultsClientDiagnostics, Pipeline, _deletedVaultVaultsRestClient.CreatePurgeDeletedRequest(Id.SubscriptionId, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
    }
}
