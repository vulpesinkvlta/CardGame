namespace Core.Domain
{
    public class CardInstance
    {
        public string InstanceId { get; }

        public string DefinitionId { get; }

        public CardInstance(
            string instanceId,
            string definitionId)
        {
            InstanceId = instanceId;
            DefinitionId = definitionId;
        }
    }
}
