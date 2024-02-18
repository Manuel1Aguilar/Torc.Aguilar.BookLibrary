import { useState, useEffect, useCallback } from 'react';
import * as React from 'react';
import './App.css';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import {
    Table,
    TableHead,
    TableBody,
    TableRow,
    TableCell,
    TablePagination,
    Card
} from '@mui/material';

interface Book {
    id: number;
    title: string;
    publisher: string;
    authors: string;
    type: string;
    isbn: string;
    category: string;
    status: string;
    availableCopies: string;
}
interface BookFilter {
    author?: string;
    isbn?: string;
    status?: string;
}
function App() {
    const [books, setBooks] = useState<Book[]>();
    const [booksCount, setBooksCount] = useState(0);
    const [searchFilter, setSearchFilter] = useState<BookFilter>({
        author: "",
        status: "",
        isbn: ""
    });
    const [controller, setController] = useState({
        page: 0,
        rowsPerPage: 10
    })

    const populateBooksData = useCallback(async () => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                author: searchFilter.author,
                isbn: searchFilter.isbn,
                status: searchFilter.status,
            })
        };

        const response = await fetch(`Books/filter/${controller.page}/${controller.rowsPerPage}`, requestOptions);
        const data = await response.json();
        setBooks(data.result);
        setBooksCount(data.total);
    }, [searchFilter, controller]); 

    useEffect(() => {
        populateBooksData();
    }, [populateBooksData, controller.page, controller.rowsPerPage]);

    const handleSearch = () => {
        populateBooksData();
    };


    const handlePageChange = (_event: React.MouseEvent<HTMLButtonElement, MouseEvent> | null, page: number) => {
        setController({
            ...controller,
            page: page
        });
    };

    const handleChangeRowsPerPage = (event: React.ChangeEvent<HTMLInputElement>) => {
        setController({
            ...controller,
            rowsPerPage: parseInt(event.target.value, 10),
            page: 0
        });
    };
    const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>): void => {
        const { id, value } = event.target;
        setSearchFilter(prevState => ({
            ...prevState,
            [id]: value
        }));
    };
    const contents = books === undefined
        ? <p><em>Loading...</em></p>
        :
        <Card>
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>
                            Book Title
                        </TableCell>
                        <TableCell>
                            Publisher
                        </TableCell>
                        <TableCell>
                            Authors
                        </TableCell>
                        <TableCell>
                            Type
                        </TableCell>
                        <TableCell>
                            ISBN
                        </TableCell>
                        <TableCell>
                            Category
                        </TableCell>
                        <TableCell>
                            Available Copies
                        </TableCell>
                        <TableCell>
                            Status
                        </TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {books.map((book) => (
                        <TableRow key={book.id} >
                            <TableCell>
                                {book.title}
                            </TableCell>
                            <TableCell>
                                {book.publisher}
                            </TableCell>
                            <TableCell>
                                {book.authors}
                            </TableCell>
                            <TableCell>
                                {book.type}
                            </TableCell>
                            <TableCell>
                                {book.isbn}
                            </TableCell>
                            <TableCell>
                                {book.category}
                            </TableCell>
                            <TableCell>
                                {book.availableCopies}
                            </TableCell>
                            <TableCell>
                                {book.status}
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
            <TablePagination
                component="div"
                onPageChange={handlePageChange}
                page={controller.page}
                count={booksCount}
                rowsPerPage={controller.rowsPerPage}
                onRowsPerPageChange={handleChangeRowsPerPage}
                rowsPerPageOptions={[5, 10, 25]}
            />
        </Card>

    const searchGrid =
        <Grid container
            p={8}
            direction="row">
            <Grid item sm={4}>
                <TextField
                    id="author"
                    label="Author"
                    value={searchFilter.author} 
                    onChange={handleSearchChange}
                />
            </Grid>
            <Grid item sm={4}>
                <TextField
                    id="isbn"
                    label="ISBN"
                    value={searchFilter.isbn} 
                    onChange={handleSearchChange}
                />
            </Grid>
            <Grid item sm={4}>
                <TextField
                    id="status"
                    label="Status"
                    value={searchFilter.status} 
                    onChange={handleSearchChange}
                />
            </Grid>

            <Grid container item sm={12} justifyContent="flex-end" style={{ paddingTop: 16 }}>
                <Button onClick={handleSearch} variant="outlined" style={{ padding: '8px 16px' }}>Search</Button>
            </Grid>
        </Grid>;

    return (
        <Paper elevation={8}>
            <h1 id="tableLabel">Books</h1>
            {searchGrid}
            {contents}
        </Paper >
    );
}

export default App;