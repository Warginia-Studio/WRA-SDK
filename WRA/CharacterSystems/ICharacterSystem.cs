namespace WRA.CharacterSystems
{
    public interface ICharacterSystem 
    {
        CharacterObject CharacterObject { get; }
        
        void SetCharacterObject(CharacterObject characterObject);
    }
}
