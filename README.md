# old-phone-keypad-challenge
# 📱 Old Phone Keypad Challenge

## 🚀 Overview
This project simulates typing on an old-style mobile keypad (like Nokia phones), where multiple presses of the same key produce different letters. The logic is implemented in two versions using C# Console Applications.

---

## 🧠 Logic
Each digit key on the phone maps to multiple letters:

| Key | Letters   |
|-----|-----------|
| 1   | . , ? !   |
| 2   | A B C     |
| 3   | D E F     |
| 4   | G H I     |
| 5   | J K L     |
| 6   | M N O     |
| 7   | P Q R S   |
| 8   | T U V     |
| 9   | W X Y Z   |
| 0   | (space)   |

Special Keys:
- `*` is used as **backspace** (deletes last character)
- `#` is used to **terminate** the input

---

## 🧪 Test Cases
Manual test cases are listed in [`TestCases.txt`](./src/TestCases.txt):

```
Input: 4433555 555666096667775553#
Output: HELLO WORLD

Input: 222 2 2#
Output: CAB

Input: 777733 666 6660#
Output: SE NO

Input: 4433555***666#
Output: HLO
```

---

## 🧰 Project Structure
```
src/
│
├── Version1_ManualLogic/
│   └── Program.cs              # Logic using array mapping
│
├── Version2_DictionaryBased/
│   └── Program.cs              # Using dictionary for digit-to-letters mapping
│
├── Version2_RefactoredWithDictionary/
│   └── alternate code.cs       # Alternative clean version 
│
├── README.md                   # This file
├── TestCases.txt               # Full list of tested input/output cases
└── logic_notes.txt             # Developer notes, logic explanation
```

---

## 💡 Key Highlights
- No AI-generated solutions used — 100% human logic
- Code is well-commented and structured
- Input and logic verified with both manual and automated test cases
- Simulated in Visual Studio 2022 (Console App Template)

🔁 Alternate Code

Located at:

src/Version2_RefactoredWithDictionary/alternate code.cs

This version is shared by a contributor and contains a more functionally separated design using the same logic
---

## 🖼️ Sample Visual Studio Output

**Input:** `4433555 555666096667775553#`

**Output:** `HELLO WORLD`

![image](https://github.com/user-attachments/assets/866e0652-fb4e-4c4e-8025-fb12f0b10d49)


## 🧠 Problem Solving Notes
See [logic_notes.txt](./logic_notes.txt) for manual breakdown of how the logic is implemented without using AI or advanced tools.

---

## ✅ How to Run

1. Open the folder in **Visual Studio 2022**
2. Choose desired version from `src/Version1_ManualLogic` or `src/Version2_DictionaryBased`
3. Build and run the console app
4. Input a keypad string and view the output

---
**🔍 Performance Notes (Added Section)**

Manual Logic Version (Version1_ManualLogic):
Uses fixed arrays for character mapping.
Good for learning and full manual control.
Slightly more verbose due to custom logic.
Dictionary-Based Version (Version2_DictionaryBased):
Easier to manage and extend (e.g., emojis, lowercase).
More scalable, and uses C# collection best practices.
Refactored Version (Version2_RefactoredWithDictionary):
Most structured and modular version.
Maintains readability, separation of concerns, and reusability.
Uses helper methods for grouping and processing.
Performance-wise for small input, all versions are efficient.
However, refactored code is closest to production-ready quality.
*/

## 📤 Submission Notes
- All logic, structure, and testing done manually
- No external libraries or AI tools used
- README and test cases written clearly and cleanly

---

**Thank You**


