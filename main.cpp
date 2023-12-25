#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

string solution(string my_string, int n)
{
    string answer = "";

    for (int i = 0; i < my_string.size(); ++i)
    {
        for (int j = 0; j < n; ++j)
        {
            answer += (my_string[i]);
        }
    }

    return answer;
}

int main()
{
    std::cout << "Hello, World!" << std::endl;

    solution("hello", 3);

    return 0;
}


