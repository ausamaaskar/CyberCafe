using CyberCafe;
using CyberCafe.Models;
using Google.Cloud.Firestore;

public interface IFirestoreController
{
    Task AddDocumentAsync(string collectionName, string documentId, string fieldName, object data);
    Task DeleteFieldAsync(string collectionName, string documentId, string fieldName);
    Task<DocumentSnapshot> GetDocumentAsync(string collectionName, string documentId);
    Task UpdateFieldAsync(string collectionName, string documentId, string fieldName, string fieldValue);
    Task UpdateSessionStatus(string collectionName, string documentId, string fieldName, string status);
}