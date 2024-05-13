"use client"

import { getDiamond } from "@/api/apiClient";
import styles from "./page.module.css";
import { ChangeEvent, useEffect, useState } from "react";

const letters = Array.from(Array(26)).map((e, i) => String.fromCharCode(i + 65));

export default function Home() {

    const [diamond, setDiamond] = useState<string[]>()
    const [renderedDiamond, setRenderedDiamond] = useState('');

    const handleLetterChanged = async (e: ChangeEvent<HTMLSelectElement>) => {
        const selectedLetter = e.currentTarget.value;

        if (selectedLetter) {
            const diamond = await getDiamond(selectedLetter);

            setDiamond(diamond);
            setRenderedDiamond(diamond.join('\n').replaceAll('_', ' '))
        }
    }

    return (
        <main className={styles.main}>

            <div className="">
                <h1>Create Diamond</h1>
                <select defaultValue="" style={{ marginTop: '10px' }} onChange={handleLetterChanged}>
                    <option value="" disabled hidden>Choose Max Letter</option>
                    {letters.map(letter => (
                        <option key={letter} value={letter}>{letter}</option>
                    ))}
                </select>

                <div style={{ backgroundColor: 'white', marginTop: '10px', width: 'fit-content' }}>
                    <code style={{ whiteSpace: 'break-spaces' }}>{renderedDiamond}</code>
                </div>
            </div>

            <div className={styles.grid}>
            </div>
        </main >
    );
}
