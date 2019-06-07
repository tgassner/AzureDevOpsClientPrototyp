using System;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System.Collections.Generic;
using System.Text;

namespace AzureDevOpsClientPrototypLogic {
    public class Downloader {
        public string download(string orgName, string personalAccessToken, string projectName, int workItemId) {
            var uri = new Uri("https://dev.azure.com/" + orgName);

            var credentials = new VssBasicCredential("", personalAccessToken);

            var connection = new VssConnection(uri, credentials);
            var workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();

            WorkItem workItem = workItemTrackingHttpClient.GetWorkItemAsync(projectName, workItemId, null, null, WorkItemExpand.All, null).Result;
            string workItemString = determineWorkItemString(workItem);

            WorkItemComments workItemComments = workItemTrackingHttpClient.GetCommentsAsync(projectName, workItemId).Result;
            string workItemCommentsString = determineWorkItemCommentsString(workItemComments);

            List<WorkItemUpdate> workItemUpdates = workItemTrackingHttpClient.GetUpdatesAsync(projectName, workItemId).Result;
            string workItemCommentUpdatesString = determineWorkItemCommentsUpdatesString(workItemUpdates);

            return workItemString + workItemCommentsString + workItemCommentUpdatesString;
        }

        static string determineWorkItemCommentsUpdatesString(List<WorkItemUpdate> workItemUpdates) {
            if (workItemUpdates == null || workItemUpdates.Count == 0) {
                return "";
            }

            IList<string> strs = new List<string>();
            strs.Add("WorkItemUpdates: ");

            foreach (WorkItemUpdate workItemUpdate in workItemUpdates) {
                strs.Add(createBlanks(4) + "WorkItemUpdate: ");
                strs.Add(createBlanks(8) + "Id: " + workItemUpdate.Id);
                strs.Add(createBlanks(8) + "Rev: " + workItemUpdate.Rev);
                strs.Add(createBlanks(8) + "RevisedBy: " + workItemUpdate.RevisedBy);
                strs.Add(createBlanks(8) + "RevisedBy: " + workItemUpdate.RevisedDate);
                strs.Add(createBlanks(8) + "Url: " + workItemUpdate.Url);
                strs.Add(createBlanks(8) + "WorkItemId: " + workItemUpdate.WorkItemId);
                strs.AddRange(linksToStringList(12, workItemUpdate.Links));
                strs.AddRange(relationsToStringList(12, workItemUpdate.Relations));
            }

            return mergeStringListItems(strs);
        }

        static IList<string> relationsToStringList(int blanksPrefix, WorkItemRelationUpdates relations) {
            IList<string> strs = new List<string>();
            if (relations == null) {
                return strs;
            }

            strs.Add(createBlanks(blanksPrefix) + "Relations: ");

            if (relations.Added != null) {
                strs.Add(createBlanks(blanksPrefix + 4) + "Added: ");
                foreach (WorkItemRelation workItemRelation in relations.Added) {
                    strs.Add(createBlanks(blanksPrefix + 8) + "Relation: ");
                    strs.Add(createBlanks(blanksPrefix + 12) + "Rel: " + workItemRelation.Rel);
                    strs.Add(createBlanks(blanksPrefix + 12) + "Title: " + workItemRelation.Title);
                    strs.Add(createBlanks(blanksPrefix + 12) + "Url: " + workItemRelation.Url);
                    strs.AddRange(attributedToStringList(blanksPrefix + 12, workItemRelation.Attributes));
                }
            }

            return strs;
        }

        static IList<string> attributedToStringList(int blanksPrefix, IDictionary<string, object> attributes) {
            IList<string> strs = new List<string>();
            if (attributes == null || attributes.Count == 0) {
                return strs;
            }

            strs.Add(createBlanks(blanksPrefix) + "Attributes: ");
            foreach (var attribute in attributes) {
                strs.Add(createBlanks(blanksPrefix + 4) + attribute.Key + ": " + attribute.Value);
            }

            return strs;
        }

        static string determineWorkItemCommentsString(WorkItemComments workItemComments) {
            if (workItemComments == null) {
                return "";
            }
            IList<string> strs = new List<string>();

            strs.Add("WorkItemComments: ");
            strs.Add(createBlanks(4) + "TotalCount: " + workItemComments.TotalCount);
            strs.Add(createBlanks(4) + "Count: " + workItemComments.Count);

            if (!string.IsNullOrWhiteSpace(workItemComments.Url)) {
                strs.Add(createBlanks(4) + "Url: " + workItemComments.Url);
            }

            strs.AddRange(linksToStringList(4, workItemComments.Links));
            strs.AddRange(commentsToStringList(4, workItemComments.Comments));


            return mergeStringListItems(strs);
        }

        static IList<string> commentsToStringList(int blanksPrefix, IEnumerable<WorkItemComment> workItemComments) {
            IList<string> strs = new List<string>();

            if (workItemComments == null) {
                return strs;
            }

            strs.Add(createBlanks(blanksPrefix) + "Comments: ");
            foreach (WorkItemComment workItemComment in workItemComments) {
                strs.Add(createBlanks(blanksPrefix + 4) + "Comment: ");
                strs.AddRange(linksToStringList(blanksPrefix + 8, workItemComment.Links));
                strs.AddRange(IdentityRefToStringList(blanksPrefix + 4, workItemComment.RevisedBy, "RevisedBy"));
                strs.Add(createBlanks(blanksPrefix + 8) + "RevisedDate: " + workItemComment.RevisedDate);
                strs.Add(createBlanks(blanksPrefix + 8) + "Revision: " + workItemComment.Revision);
                strs.Add(createBlanks(blanksPrefix + 8) + "Text: " + workItemComment.Text);
                strs.Add(createBlanks(blanksPrefix + 8) + "Url: " + workItemComment.Url);
            }

            return strs;
        }

        static string determineWorkItemString(WorkItem workItem) {
            IList<string> strs = new List<string>();

            strs.Add("WorkItem: ");
            strs.Add(createBlanks(4) + "Id: " + workItem.Id);
            strs.Add(createBlanks(4) + "Rev: " + workItem.Rev);
            if (workItem?.Relations != null) {
                strs.Add(createBlanks(4) + "Relations: ");
                //var validSourceCodeLinkTypes = new List<string> { "ArtifactLink", "Hyperlink" };
                foreach (var relation in workItem.Relations) {
                    //if (validSourceCodeLinkTypes.Contains(relation.Rel)) {
                    strs.Add(createBlanks(8) + relation.Rel + ": " + relation.Url);
                    //}
                }
            }

            strs.AddRange(linksToStringList(4, workItem?.Links));
            strs.AddRange(fieldsToStringList(4, workItem?.Fields));

            return mergeStringListItems(strs);
        }

        static IList<string> fieldsToStringList(int blanksPrefix, IDictionary<String, Object> fields) {
            IList<string> strs = new List<string>();

            if (fields == null || fields.Count == 0) {
                return strs;
            }

            strs.Add(createBlanks(blanksPrefix) + "Fields: ");
            foreach (var field in fields) {
                if (field.Value is IdentityRef) {
                    IdentityRef identityRef = (IdentityRef)field.Value;
                    strs.AddRange(IdentityRefToStringList(blanksPrefix + 4, identityRef, field.Key));
                } else {
                    strs.Add(createBlanks(blanksPrefix + 4) + field.Key + ": " + field.Value);
                }
            }

            return strs;
        }

        static IList<string> IdentityRefToStringList(int blanksPrefix, IdentityRef identityRef, string keyString) {

            IList<string> strs = new List<string>();

            if (identityRef == null) {
                return strs;
            }

            strs.Add(createBlanks(blanksPrefix) + keyString);

            if (!string.IsNullOrWhiteSpace(identityRef.Id)) {
                strs.Add(createBlanks(blanksPrefix + 4) + "Id: " + identityRef.Id);
            }

            if (!string.IsNullOrWhiteSpace(identityRef.DisplayName)) {
                strs.Add(createBlanks(blanksPrefix + 4) + "DisplayName: " + identityRef.DisplayName);
            }

            if (!string.IsNullOrWhiteSpace(identityRef.DirectoryAlias)) {
                strs.Add(createBlanks(blanksPrefix + 4) + "DirectoryAlias: " + identityRef.DirectoryAlias);
            }

            if (!string.IsNullOrWhiteSpace(identityRef.ImageUrl)) {
                strs.Add(createBlanks(blanksPrefix + 4) + "ImageUrl: " + identityRef.ImageUrl);
            }

            strs.Add(createBlanks(blanksPrefix + 4) + "inactive: " + identityRef.Inactive.ToString());
            strs.Add(createBlanks(blanksPrefix + 4) + "AadIdentity: " + identityRef.IsAadIdentity.ToString());
            strs.Add(createBlanks(blanksPrefix + 4) + "container: " + identityRef.IsContainer.ToString());
            strs.Add(createBlanks(blanksPrefix + 4) + "deletedInOrigin: " + identityRef.IsDeletedInOrigin.ToString());

            if (!string.IsNullOrWhiteSpace(identityRef.ProfileUrl)) {
                strs.Add(createBlanks(blanksPrefix + 4) + "ProfileUrl: " + identityRef.ProfileUrl);
            }

            if (!string.IsNullOrWhiteSpace(identityRef.UniqueName)) {
                strs.Add(createBlanks(blanksPrefix + 4) + "UniqueName: " + identityRef.UniqueName);
            }

            if (!string.IsNullOrWhiteSpace(identityRef.Url)) {
                strs.Add(createBlanks(blanksPrefix + 4) + "Url: " + identityRef.Url);
            }

            strs.AddRange(linksToStringList(blanksPrefix + 4, identityRef.Links));

            strs.AddRange(subjectDescriptorToStringList(blanksPrefix + 4, identityRef.Descriptor));

            return strs;
        }

        static IList<string> linksToStringList(int blanksPrefix, ReferenceLinks referenceLinks) {
            IList<string> strs = new List<string>();

            if (referenceLinks == null || referenceLinks.Links == null) {
                return strs;
            }

            strs.Add(createBlanks(blanksPrefix) + "Links: ");
            foreach (var link in referenceLinks.Links) {
                if (link.Value is ReferenceLink) {
                    ReferenceLink referenceLink = (ReferenceLink)link.Value;
                    strs.Add(createBlanks(blanksPrefix + 4) + link.Key + ": " + referenceLink.Href);
                } else {
                    strs.Add(createBlanks(blanksPrefix + 4) + link.Key + ": " + link.Value);
                }

            }

            return strs;
        }

        static IList<string> subjectDescriptorToStringList(int blanksPrefix, SubjectDescriptor subjectDescriptor) {
            IList<string> strs = new List<string>();

            if (subjectDescriptor == null) {
                return strs;
            }

            strs.Add(createBlanks(blanksPrefix) + "Descriptor: ");
            strs.Add(createBlanks(blanksPrefix + 4) + "Identifier: " + subjectDescriptor.Identifier);
            strs.Add(createBlanks(blanksPrefix + 4) + "SubjectType: " + subjectDescriptor.SubjectType);

            return strs;
        }

        static string mergeStringListItems(IList<String> strs) {
            if (strs == null || strs.Count == 0) {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            foreach (string str in strs) {
                sb.Append(str).Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        static string createBlanks(int noOfBlanks) {
            return new StringBuilder().Append(' ', noOfBlanks).ToString();
        }

    }
}
