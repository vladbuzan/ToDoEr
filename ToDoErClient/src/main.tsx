import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import '@mantine/core/styles.css'
import {Button, createTheme, MantineProvider} from "@mantine/core"

const theme = createTheme({
    components: {
        Button: Button.extend({
            styles: {
                root: {backgroundColor: 'red'},
                label: {color: 'blue'},
                inner: {fontSize: 20},
            }
        })
    }
})


ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <MantineProvider theme={theme}>
            <App/>
        </MantineProvider>
    </React.StrictMode>,
)
