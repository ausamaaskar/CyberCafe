using CyberCafe;
using CyberCafe.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

public class FirestoreController : IFirestoreController
{
    private readonly FirestoreDb _db;

    public FirestoreController(string projectId, string pathToServiceAccountKey)
    {
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", pathToServiceAccountKey);
        _db = FirestoreDb.Create(projectId);
    }

    public async Task<DocumentSnapshot> GetDocumentAsync(string collectionName, string documentId)
    {
        DocumentReference docRef = _db.Collection(collectionName).Document(documentId);
        DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
        return snapshot;
    }

    public async Task AddDocumentAsync(string collectionName, string documentId, string fieldName, object data)
    {
        DocumentReference docRef = _db.Collection(collectionName).Document(documentId);
        var dataString = JsonConvert.SerializeObject(data);
        var field = new Dictionary<string, string>
        {
            { fieldName, dataString }
        };

        await docRef.SetAsync(field, SetOptions.MergeAll);
    }

    public async Task DeleteFieldAsync(string collectionName, string documentId, string fieldName)
    {
        DocumentReference docRef = _db.Collection(collectionName).Document(documentId);
        var fieldUpdates = new Dictionary<string, object>
        {
            { fieldName, FieldValue.Delete }
        };

        await docRef.UpdateAsync(fieldUpdates);
    }

    public async Task UpdateFieldAsync(string collectionName, string documentId, string fieldName, string fieldValue)
    {
        DocumentReference docRef = _db.Collection(collectionName).Document(documentId);
        await docRef.UpdateAsync(fieldName, fieldValue);

    }
}
