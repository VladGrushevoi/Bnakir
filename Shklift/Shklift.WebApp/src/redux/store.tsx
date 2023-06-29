import { configureStore } from "@reduxjs/toolkit"
import { transactionSlice } from "./transactionSlice"

export const storeApp = configureStore({
    reducer: {
        transaction: transactionSlice.reducer
    }
})

export type RootState = ReturnType<typeof storeApp.getState>
export type AppDispatch = typeof storeApp.dispatch