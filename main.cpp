#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;


string solution(string my_string, string letter)
{
    string answer = "";

    // 문자열 my_string과 문자 letter이 매개변수로 주어집니다. my_string에서 letter를 제거한 문자열을 return하도록 solution 함수를 완성해주세요.

    my_string.erase(remove(my_string.begin(),my_string.end(), letter[0]),my_string.end());
    return my_string;
}

int main()
{
    std::cout << "Hello, World!" << std::endl;

    return 0;
}


