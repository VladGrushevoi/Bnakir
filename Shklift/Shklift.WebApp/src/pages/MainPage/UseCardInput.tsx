import { useInput } from "../../hooks/InputHook"

export const useCardInput = () => {
    const cardSenderNumber = useCardNumberInput();
    const cardReceiverNumber = useCardNumberInput();
    const dateSender = useDateInput();
    const cvvInput = useInput("");
    const moneyInput = useInput("");

    const handleInputInfo = (e : React.FormEvent) => {
        e.preventDefault();
        const info = {
            sender: cardSenderNumber.cardNumber.map(i => i.value).join(""),
            receiver:cardReceiverNumber.cardNumber.map(i => i.value).join(""),
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

const useCardNumberInput = () => {
    const numbers1 = useInput("");
    const numbers2 = useInput("");
    const numbers3 = useInput("");
    const numbers4 = useInput("");
    return {
        cardNumber: [numbers1, numbers2, numbers3, numbers4]
    }
}

const useDateInput = () => {
    const month = useInput("");
    const year = useInput("");

    return {
        cardDate: {
            month, year
        }
    }
}