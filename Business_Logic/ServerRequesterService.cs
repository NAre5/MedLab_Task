namespace Business_Logic
{
    public static class ServerRequesterService
    {
        private static KnowledgeService.KnowledgeLibraryWSSoapClient _knowledgeClient = new KnowledgeService.KnowledgeLibraryWSSoapClient("KnowledgeService");
        private static DataService.aKontrollerSoapClient _dataClient = new DataService.aKontrollerSoapClient("DataService");


        public static KnowledgeService.KnowledgeBase GetKnowledgeBase(long KBID)
        {
            return _knowledgeClient.GetKnowledgeBase(KBID);
        }
        public static DataService.DataPoint[] GetDataByConcept(long projectID, string conceptName)
        {
            return _dataClient.GetDataByConcept(projectID,conceptName);
        }
    }
}
