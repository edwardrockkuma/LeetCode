Feature: LeetCode Test
	In order to Validate the Method
    As Tester
    BDD Lab

# Background:
#     Given Put your Background here

@leetcode
Scenario: Add Two Nums
    Given Number arrays: 2,7,11,15,7
    And Taget is: 9
	When Run the test
    Then Result should be: 0,1
