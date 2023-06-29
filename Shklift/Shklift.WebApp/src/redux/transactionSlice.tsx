import { createSlice } from "@reduxjs/toolkit";
import { TransactionResponse } from "../axios/axios";
import type { PayloadAction } from "@reduxjs/toolkit/dist/createAction";
import { RootState } from "./store";

const initialState = {
    id: "",
    isConfirmTransaction: false,
    amountMoney: "",
    commission: "",
    dateOfOperation: "",
    fromCardNumber: "",
    toCardNumber: ""
} as TransactionResponse

export const transactionSlice = createSlice({
    name: "transaction",
    initialState,
    reducers: {
        setTransactionResponse: (state, action: PayloadAction<TransactionResponse>) => {
            console.log(action, "ACTION BLYA")
            state = action.payload
            console.log(state, "AFTER BLYA")
            return state
        }
    }
})

export const { setTransactionResponse } = transactionSlice.actions;
export const getTransactionData = (state: RootState) => state.transaction;

export default transactionSlice.reducer