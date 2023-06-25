import { useInput } from "../../hooks/InputHook"

export const useCardInput = () => {
    const cardSenderNumber = useCardNumberInput("");
    const cardReceiverNumber = useCardNumberInput("");
    const dateSender = useDateInput();
    const cvvInput = useInput("", "cvv");
    const moneyInput = useInput("", "nomey");

    const handleInputInfo = (e : React.FormEvent) => {
        e.preventDefault();
        const info = {
            sender: cardSenderNumber.allPart,
            receiver:cardReceiverNumber.allPart,
            date: dateSender.cardDate.month.value + "." + dateSender.cardDate.year.value,
            cvv: cvvInput.value,
            amountMoney: moneyInput.value 
        }
        console.log(info);
    }

    return {
        cardReceiverNumber,
        cardSenderNumber,
        dateSender,
        cvvInput,
        moneyInput,
        handleInputInfo,
    }
}

const useCardNumberInput = (init:string) => {
    const numbers1 = useInput(init, `part1 ${Math.random()}`);
    const numbers2 = useInput(init, `part2 ${Math.random()}`);
    const numbers3 = useInput(init, `part3 ${Math.random()}`);
    const numbers4 = useInput(init, `part4 ${Math.random()}`);
    return {
        firstPart: numbers1,
        secondPart: numbers2,
        thirdPart: numbers3,
        fourthPart: numbers4,
        allPart: numbers1.value + "" + numbers2.value + "" + numbers3.value + "" + numbers4.value,
    }
}

const useDateInput = () => {
    const month = useInput("", "month");
    const year = useInput("", "year");

    return {
        cardDate: {
            month, year
        }
    }
}