#include <iostream>
#include <vector>

using namespace std;


vector<int> solution(vector<int> num_list)
{
    vector<int> answer;

    // 원소의 숫자를 거꾸로
    for (int i = num_list.size() - 1; i < num_list.size(); --i)
    {
        answer.push_back(num_list[i]);
    }

    //reverse(num_list.begin(), num_list.end());

    return answer;
}

int main()
{
    std::cout << "Hello, World!" << std::endl;

    solution({1, 2, 3, 4, 5});

    return 0;
}


