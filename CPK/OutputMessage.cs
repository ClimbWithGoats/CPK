namespace CPK
{
    public class OutputMessage
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string? ObjectType { get; set; }
        public PipeLineAlias MethodName { get; set; }
        //public string[] param { get; set; }
        public OperationType OperationType { get; set; }
        public string? Json { get; set; }
    }
    public enum PipeLineAlias
    {
        HandlePostPZRequest = 1,
        HandlePostFZRequest = 2,
        HandlePostWZRequest = 3,
        HandlePostFARequest = 4,
        HandlePutWmsDiscrepancies = 5,
        HandlePutWmsStatusRequest = 6,
        HandlePutWmsStatusSignature = 7,
        HandleTestingRunProccesRequest = 0
    }

    public enum OperationType
    {
        ReadOnly = 0,
        Insert = 1,
        Update = 2,
        Delete = 3
    }

}
