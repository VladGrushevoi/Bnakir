import { SendTransaction, TransactionProps, TransactionResponse } from "../../axios/axios";
import { useInput } from "../../hooks/InputHook"
import { redirect } from "react-router-dom";

export const useCardInput = () => {
    const cardSenderNumber = useCardNumberInput("");
    const cardReceiverNumber = useCardNumberInput("");
    const dateSender = useDateInput();
    const cvvInput = useInput("178", "cvv");
    const moneyInput = useInput("100", "nomey");

    const handleInputInfo = async (e : React.FormEvent, handleTransaction : (data: TransactionResponse) => void) => {
        e.preventDefault();
        const transData : TransactionProps = {
            FromCardNumber: cardSenderNumber.allPart,
            FromCardCvv: cvvInput.value,
            FromCardShortExpire: dateSender.cardDate.month.value + "." + dateSender.cardDate.year.value,
            AmountMoney: Number.parseFloat(moneyInput.value),
            CardNumberReceiver: cardReceiverNumber.allPart
        }
        const result = await SendTransaction(transData);

        console.log(result, "response")
        handleTransaction(result);
        redirect("/receipt")
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
    //4411232034167137
    const numbers1 = useInput("4411", `part1 ${Math.random()}`);
    const numbers2 = useInput("2320", `part2 ${Math.random()}`);
    const numbers3 = useInput("3416", `part3 ${Math.random()}`);
    const numbers4 = useInput("7137", `part4 ${Math.random()}`);
    return {
        firstPart: numbers1,
        secondPart: numbers2,
        thirdPart: numbers3,
        fourthPart: numbers4,
        allPart: numbers1.value + "" + numbers2.value + "" + numbers3.value + "" + numbers4.value,
    }
}

const useDateInput = () => {
    const month = useInput("06", "month");
    const year = useInput("25", "year");

    return {
        cardDate: {
            month, year
        }
    }
}