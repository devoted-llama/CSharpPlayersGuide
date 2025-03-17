using System;

namespace TheSieve;

public class Sieve {
    Predicate<int> _checkNumberIsGoodPredicate;
    public Sieve(Predicate<int> checkNumberIsGoodPredicate) {
        _checkNumberIsGoodPredicate = checkNumberIsGoodPredicate;
    }
    public bool IsGood(int number) {
        return _checkNumberIsGoodPredicate(number);
    }
}
