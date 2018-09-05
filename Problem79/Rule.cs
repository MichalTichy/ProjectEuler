using System;

namespace Problem79
{
    public class Rule
    {
        public char First { get; protected set; }
        public char Second { get; protected set; }
        public char Third { get; protected set; }

        public virtual bool DoesRulePass(string input)
        {
            return DoesContainAllCharacters(input) && DoesHaveRequiredOrderOfCharacters(input);
        }
        
        protected virtual bool DoesContainAllCharacters(string input)
        {
            return input.Contains(First) && input.Contains(Second) && input.Contains(Third);
        }
        protected virtual bool DoesHaveRequiredOrderOfCharacters(string input)
        {
            bool doesPass = false;
            int indexOfSecondCharacter=0;
            do
            {
                indexOfSecondCharacter = input.IndexOf(Second,indexOfSecondCharacter+1);

                if (indexOfSecondCharacter == -1)
                    return false;

                var beforeSecondChar = input.Remove(indexOfSecondCharacter);
                var afterSecondChar = input.Remove(0, indexOfSecondCharacter+1);
                doesPass = beforeSecondChar.Contains(First) && afterSecondChar.Contains(Third);

            } while (!doesPass && indexOfSecondCharacter!=-1);

            return doesPass;
        }

        public Rule(string characterSequence)
        {
            if (characterSequence.Length != 3)
                throw new ArgumentException("Character sequence has to be exactly 3 characters long.");

            First = characterSequence[0];
            Second = characterSequence[1];
            Third = characterSequence[2];
        }
    }
}