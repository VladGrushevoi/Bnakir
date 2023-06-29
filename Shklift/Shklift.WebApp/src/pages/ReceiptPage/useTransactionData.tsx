import { useState } from "react";
import { TransactionResponse } from "../../axios/axios";

export function Transaction() {
    const [transactionData, setTransactionData] = useState({} as TransactionResponse)

    const HandleTransaction = (data : TransactionResponse) => {
        setTransactionData(data);
        console.log(transactionData, "set state")
    }

    return {
        transactionData,
        HandleTransaction
    }
}