export const getDiamond = async (maxLetter: string): Promise<string[]> => {

    const response = await fetch(`https://localhost:7080/diamond?maxLetter=${maxLetter}`);
    const payload = await response.json() as { data: string[] };

    return payload.data;
}