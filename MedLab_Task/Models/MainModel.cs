namespace MedLab_Task.Models
{
    public class MainModel
    {
        private static KnowledgeService.KnowledgeLibraryWSSoapClient _knowledgeClient = new KnowledgeService.KnowledgeLibraryWSSoapClient("KnowledgeLibraryWSSoap");
        private static DataService.aKontrollerSoapClient _dataClient = new DataService.aKontrollerSoapClient("aKontrollerSoap");

        static public KnowledgeService.KnowledgeBase GetKnowledgeBase(long KBID)
        {
            return _knowledgeClient.GetKnowledgeBase(KBID);
        }
        static public DataService.DataPoint[] GetDataByConcept(long projectID, string conceptName)
        {
            return _dataClient.GetDataByConcept(projectID, conceptName);
        }
    }
}

