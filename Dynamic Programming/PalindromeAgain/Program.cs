
class Solution
{
    int PalindromeAgain(string s)
    {


        int Solver(int i, int j)
        {
            // Logical Thinking, simple choices 
            // Finding the case case is slightly challenging 
            if (i == j) return 1;
            if (i + 1 == r)
                // Say we have AB then answer will be 2: A,B
                // But for AA, answer will be 3: A,A,AB
                // Notice, the question asks for unique indexes not sequences 
                return 2 + (s[l] == s[r]? 1:0);
            int cur = 0;
            if (s[i] == s[j])
               // For string: ABCA 
               // The Solver function will calculate the number of valid ones for 
               // Solver(i + 1, j - 1) is equivalent to sending Solver(BC)
               // According to the base case, it returns 2 
               // The two cases are
               // B i.e. (ABA) because the surrounding A is waiting outside
               // C i.e. (ACA) because the surrounding A is waiting outside
               // But it will not consider the case of the surrounding A on its own 
               // So we add one for that case 
                cur = 1 + Solver(i + 1, j - 1);  
 

            // Continuing our exmaple 
            // Solver(i + 1, j) is equivalent to sending Solver(BCA) It goes to CA, BC, C 
            // CA -> C,A --- BC -> B, C
            // C,A,B,C,C
            // Solver(i, j - 1) is equivalent to sending Solver(ABC) It goes to BC, AB, B
            // BC -> B,C --- AB -> A, B
            // B,C,A,B,B
            // B, C are different from B,C in Solver(i + 1, j - 1) because there is no surrounding A here 
            // We have some issues We calculate the BC twice one time in Solver(i + 1, j) 
            // and another in Solver(i + 1, j - 1) if say the s[i] and s[j] were equal
            cur += Solver(i + 1, j) + Solver(i, j - 1);

            // to remove duplicates, but I don't understand how.     
            cur -=Solver(i + 1, j - 1); 
            return cur;
        }
    }
}