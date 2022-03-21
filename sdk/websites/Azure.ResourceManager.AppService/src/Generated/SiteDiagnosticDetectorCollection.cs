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
    /// <summary> A class representing collection of SiteDiagnosticDetector and their operations over its parent. </summary>
    public partial class SiteDiagnosticDetectorCollection : ArmCollection, IEnumerable<SiteDiagnosticDetector>, IAsyncEnumerable<SiteDiagnosticDetector>
    {
        private readonly ClientDiagnostics _siteDiagnosticDetectorDiagnosticsClientDiagnostics;
        private readonly DiagnosticsRestOperations _siteDiagnosticDetectorDiagnosticsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SiteDiagnosticDetectorCollection"/> class for mocking. </summary>
        protected SiteDiagnosticDetectorCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SiteDiagnosticDetectorCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SiteDiagnosticDetectorCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteDiagnosticDetectorDiagnosticsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteDiagnosticDetector.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(SiteDiagnosticDetector.ResourceType, out string siteDiagnosticDetectorDiagnosticsApiVersion);
            _siteDiagnosticDetectorDiagnosticsRestClient = new DiagnosticsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteDiagnosticDetectorDiagnosticsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SiteDiagnostic.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SiteDiagnostic.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Get Detector
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetSiteDetector
        /// </summary>
        /// <param name="detectorName"> Detector Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual async Task<Response<SiteDiagnosticDetector>> GetAsync(string detectorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetectorCollection.Get");
            scope.Start();
            try
            {
                var response = await _siteDiagnosticDetectorDiagnosticsRestClient.GetSiteDetectorAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, detectorName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteDiagnosticDetector(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get Detector
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetSiteDetector
        /// </summary>
        /// <param name="detectorName"> Detector Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual Response<SiteDiagnosticDetector> Get(string detectorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetectorCollection.Get");
            scope.Start();
            try
            {
                var response = _siteDiagnosticDetectorDiagnosticsRestClient.GetSiteDetector(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, detectorName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteDiagnosticDetector(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get Detectors
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors
        /// Operation Id: Diagnostics_ListSiteDetectors
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteDiagnosticDetector" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteDiagnosticDetector> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteDiagnosticDetector>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetectorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteDiagnosticDetectorDiagnosticsRestClient.ListSiteDetectorsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteDiagnosticDetector(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SiteDiagnosticDetector>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetectorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteDiagnosticDetectorDiagnosticsRestClient.ListSiteDetectorsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteDiagnosticDetector(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Description for Get Detectors
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors
        /// Operation Id: Diagnostics_ListSiteDetectors
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteDiagnosticDetector" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteDiagnosticDetector> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SiteDiagnosticDetector> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetectorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteDiagnosticDetectorDiagnosticsRestClient.ListSiteDetectors(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteDiagnosticDetector(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SiteDiagnosticDetector> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetectorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteDiagnosticDetectorDiagnosticsRestClient.ListSiteDetectorsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteDiagnosticDetector(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetSiteDetector
        /// </summary>
        /// <param name="detectorName"> Detector Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string detectorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetectorCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(detectorName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetSiteDetector
        /// </summary>
        /// <param name="detectorName"> Detector Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual Response<bool> Exists(string detectorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetectorCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(detectorName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetSiteDetector
        /// </summary>
        /// <param name="detectorName"> Detector Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual async Task<Response<SiteDiagnosticDetector>> GetIfExistsAsync(string detectorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetectorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _siteDiagnosticDetectorDiagnosticsRestClient.GetSiteDetectorAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, detectorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SiteDiagnosticDetector>(null, response.GetRawResponse());
                return Response.FromValue(new SiteDiagnosticDetector(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetSiteDetector
        /// </summary>
        /// <param name="detectorName"> Detector Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual Response<SiteDiagnosticDetector> GetIfExists(string detectorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetectorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _siteDiagnosticDetectorDiagnosticsRestClient.GetSiteDetector(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, detectorName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SiteDiagnosticDetector>(null, response.GetRawResponse());
                return Response.FromValue(new SiteDiagnosticDetector(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SiteDiagnosticDetector> IEnumerable<SiteDiagnosticDetector>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SiteDiagnosticDetector> IAsyncEnumerable<SiteDiagnosticDetector>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
